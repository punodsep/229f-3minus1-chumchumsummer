using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderUIController : MonoBehaviour
{
    public GameObject orderPanel;

    public TextMeshProUGUI iceText;
    public TextMeshProUGUI syrupText;
    public TextMeshProUGUI toppingText;

    public GameObject resultPanel;
    public TextMeshProUGUI gradeText;
    public TextMeshProUGUI scoreText;


    void Update()
    {
        var gm = GameManager.Instance;

        if (gm.hasCustomer)
        {
            orderPanel.SetActive(true);
            UpdateOrderUI();
        }
        else
        {
            orderPanel.SetActive(false);
        }

        if (gm.showResult)
        {
            resultPanel.SetActive(true);

            gradeText.text = gm.lastGrade;
            scoreText.text = gm.lastScore.ToString() + " บาท";
        }
        else
        {
            resultPanel.SetActive(false);
        }
    }

    void UpdateOrderUI()
    {
        var order = GameManager.Instance.currentOrder;
        if (order == null) return;

        string iceLevel = GetLevel(order.iceAmount, 30, 80);
        string syrupLevel = GetLevel(order.syrupAmount, 20, 50);

        iceText.text = iceLevel;
        syrupText.text = syrupLevel;
        toppingText.text = "X " + order.toppingCount;
    }

    string GetLevel(int value, int min, int max)
    {
        int range = max - min;
        int low = min + range / 3;
        int high = min + (range * 2 / 3);

        if (value <= low) return "น้อย";
        if (value <= high) return "กลาง";
        return "มาก";
    }
}