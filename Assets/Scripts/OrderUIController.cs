using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderUIController : MonoBehaviour
{
    public GameObject orderPanel;

    public TextMeshProUGUI iceText;
    public TextMeshProUGUI syrupText;
    public TextMeshProUGUI toppingText;

    public GameObject serveButton;
    public GameObject spawnButton;

    void Update()
    {
        if (GameManager.Instance.hasCustomer)
        {
            orderPanel.SetActive(true);
            UpdateOrderUI();

            serveButton.SetActive(GameManager.Instance.canServe);
            spawnButton.SetActive(false);
        }
        else
        {
            orderPanel.SetActive(false);
            serveButton.SetActive(false);
            spawnButton.SetActive(true);
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