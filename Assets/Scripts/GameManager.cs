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

        currentOrder.iceAmount = Random.Range(1, 5);
        currentOrder.syrupAmount = Random.Range(1, 5);
        currentOrder.toppingCount = Random.Range(0, 3);

        currentCustomerTime = customerMaxTime;
    }
    public void SpawnCustomer()
    {
        GenerateOrder();
        hasCustomer = true;
    }

    public void ServeSuccess(int addScore)
    {
        score += addScore;
        hasCustomer = false;
        SceneManager.LoadScene("OrderScene");
    }

    void CustomerTimeout()
    {
        Debug.Log("Timeout");
        GameObject currentCupObj = GameObject.Find("CupManager(Clone)");

        if (currentCupObj != null)
        {
            Destroy(currentCupObj);
        }

        SceneManager.LoadScene("OrderScene");
        hasCustomer = false;
    }

    void GameOver()
    {
        isPlaying = false;
        SceneManager.LoadScene("GameOverScene");
    }
}