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
            scoreText.text = gm.lastScore.ToString();
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

        iceText.text = "Ice: " + order.iceAmount;
        syrupText.text = "Syrup: " + order.syrupAmount;
        toppingText.text = "Topping: " + order.toppingCount;
    }
}