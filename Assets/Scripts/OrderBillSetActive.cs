using UnityEngine;

public class OrderBillSetActive : MonoBehaviour
{
    public void OrderBillActive()
    {
        GameObject orderBillObj = GameObject.Find("OrderBill");

        if (orderBillObj != null)
        {
            orderBillObj.SetActive(false);
        }

        GameObject moneyBasketObj = GameObject.Find("MoneyBasket");

        if (moneyBasketObj != null)
        {
            moneyBasketObj.SetActive(false);
        }
    }
}
