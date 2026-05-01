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

    public float gameMaxTime = 180f;
    public float currentGameTime;

    public bool isPlaying;
    public bool hasCustomer;

    public GameObject cupPrefab;
    public Transform cupPos;

    public bool canServe;

    public string lastGrade;
    public int lastScore;

    public bool showResult;

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

    public void GenerateOrder()
    {
        GameObject obj = Instantiate(cupPrefab, cupPos.position, Quaternion.identity);

        GameObject parentObj = GameObject.Find("CupPos");

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
        hasCustomer = true;
        canServe = false;

        showResult = false;
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
        SceneManager.LoadScene("OrderScene");
    }

    void GameOver()
    {
        isPlaying = false;
        SceneManager.LoadScene("GameOverScene");
    }


}