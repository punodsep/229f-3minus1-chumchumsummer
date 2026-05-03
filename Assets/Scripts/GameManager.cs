using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public OrderData currentOrder;
    public CupData currentCup;

    public int score;

    public float customerMaxTime = 20f;
    public float currentCustomerTime;

    public float gameMaxTime = 240f;
    public float currentGameTime;

    public int startHour = 15;
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
    public GameObject orderUI;
    public GameObject orderBill;

    public GameObject endPanel;
    public GameObject gamePanel;

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

        SceneManager.sceneLoaded += OnSceneLoaded;
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "CreditScene")
        {
            isPlaying = false;
            gamePanel.SetActive(false);
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

        int totalMinutes = Mathf.FloorToInt(timePassed);

        int hour = startHour + (totalMinutes / 60);
        int minute = totalMinutes % 60;

        hour = Mathf.Min(hour, endHour);

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
        StartCoroutine(SpawnCustomerRoutine());
    }

    IEnumerator SpawnCustomerRoutine()
    {
        SFXManager.Instance.PlaySFX("CallCustomer");

        yield return new WaitForSeconds(3f);

        Transform t = GameObject.Find("Canvas").transform.Find("Go to Ice Button");
        t.gameObject.SetActive(true);

        GenerateOrder();
        SpawnRandomCustomer();
        hasCustomer = true;
        canServe = false;

        orderUI.SetActive(true);
        orderBill.SetActive(true);

        SFXManager.Instance.PlaySFX("OrderBill");

        showResult = false;
    }
    public GameObject GetCurrentCustomer()
    {
        return currentCustomer;
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
        CustomerVisual visual = currentCustomer.GetComponent<CustomerVisual>();
        if (visual != null)
        {
            visual.SetDefault();
        }
    }

    public void ServeSuccess(int addScore)
    {
        StartCoroutine(ServeSuccessRoutine(addScore));
    }

    IEnumerator ServeSuccessRoutine(int addScore)
    {
        SFXManager.Instance.PlaySFX("Customer");

        yield return new WaitForSeconds(3f);

        SFXManager.Instance.PlaySFX("Coin");

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
        lastScore = score;
        endPanel.SetActive(true);
        gamePanel.SetActive(false);
        SFXManager.Instance.PlaySFX("Coin");

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }

        Time.timeScale = 0f;
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;

        score = 0;
        currentGameTime = gameMaxTime;

        hasCustomer = false;
        canServe = false;
        isPlaying = true;
        showResult = false;

        currentOrder = null;
        currentCup = null;

        if (currentCustomer != null)
        {
            currentCustomer.SetActive(false);
            currentCustomer = null;
        }

        GameObject cup = GameObject.Find("CupManager(Clone)");
        if (cup != null)
        {
            Destroy(cup);
        }

        endPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

}