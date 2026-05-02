using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public OrderData currentOrder;
    public CupData currentCup;

    public int score;

    public float customerMaxTime = 20f;
    public float currentCustomerTime;

    public float gameMaxTime = 120f;
    public float currentGameTime;

    public int startHour = 16;
    public int endHour = 18;

    public bool isPlaying;
    public bool hasCustomer;

    public GameObject cupPrefab;
    public Transform cupPos;

    public bool canServe;

    public string lastGrade;
    public int lastScore;

    public bool showResult;

    public List<GameObject> customers;
    private GameObject currentCustomer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        var systems = FindObjectsByType<EventSystem>(FindObjectsSortMode.None);
        Debug.Log("EventSystem count = " + systems.Length);
        StartGame();
    }

    void Update()
    {
        if (!isPlaying) return;

        currentGameTime -= Time.deltaTime;
        if (currentGameTime <= 0)
            GameOver();

        if (hasCustomer)
        {
            currentCustomerTime -= Time.deltaTime;

            if (currentCustomerTime <= 0)
                CustomerTimeout();
        }
    }

    public void StartGame()
    {
        score = 0;
        currentGameTime = gameMaxTime;
        isPlaying = true;

        hasCustomer = false;
    }

    public string GetFormattedGameTime()
    {
        float timePassed = gameMaxTime - currentGameTime;

        int totalMinutes = Mathf.FloorToInt(timePassed); // 1 วิ = 1 นาที

        int hour = startHour + (totalMinutes / 60);
        int minute = totalMinutes % 60;

        hour = Mathf.Min(hour, endHour); // กันเกิน

        return string.Format("{0:00}:{1:00}", hour, minute);
    }

    public void GenerateOrder()
    {
        GameObject obj = Instantiate(cupPrefab, cupPos.position, Quaternion.identity);

        GameObject parentObj = GameObject.Find("GameManager");

        if (parentObj != null)
        {
            obj.transform.SetParent(parentObj.transform, true);
        }

        currentOrder = new OrderData();
        currentCup = new CupData();

        currentOrder.iceAmount = Random.Range(30, 80);
        currentOrder.syrupAmount = Random.Range(20, 50);
        currentOrder.toppingCount = Random.Range(1, 10);

        currentCustomerTime = customerMaxTime;
    }
    public void SpawnCustomer()
    {
        GenerateOrder();
        SpawnRandomCustomer();
        hasCustomer = true;
        canServe = false;

        showResult = false;
    }

    public void SpawnRandomCustomer()
    {
        if (currentCustomer != null)
        {
            currentCustomer.SetActive(false);
        }

        if (customers.Count == 0) return;

        int index = Random.Range(0, customers.Count);

        currentCustomer = customers[index];

        currentCustomer.SetActive(true);
    }

    public void ServeSuccess(int addScore)
    {
        score += addScore;
        hasCustomer = false;
        canServe = false;
        GameObject currentCupObj = GameObject.Find("CupManager(Clone)");

        if (currentCupObj != null)
        {
            Destroy(currentCupObj);
        }
    }

    void CustomerTimeout()
    {
        Debug.Log("Timeout");
        GameObject currentCupObj = GameObject.Find("CupManager(Clone)");

        if (currentCupObj != null)
        {
            Destroy(currentCupObj);
        }

        hasCustomer = false;
        canServe = false;
        currentCustomer.SetActive(false);
        SceneManager.LoadScene("OrderScene");
    }

    void GameOver()
    {
        isPlaying = false;
        SceneManager.LoadScene("GameOverScene");
    }


}