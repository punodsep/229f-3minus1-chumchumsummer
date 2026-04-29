using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderUIController : MonoBehaviour
{
    public GameObject orderPanel;

    public TextMeshProUGUI iceText;
    public TextMeshProUGUI syrupText;
    public TextMeshProUGUI toppingText;

    void Update()
    {
        if (GameManager.Instance.hasCustomer)
        {
            orderPanel.SetActive(true);

            UpdateOrderUI();
        }
        else
        {
            orderPanel.SetActive(false);
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