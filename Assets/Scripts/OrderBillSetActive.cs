using UnityEngine;

public class OrderBillSetActive : MonoBehaviour
{
    public void OrderBillActiveFalse()
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

    public void OrderBillActiveTrue()
    {
        GameObject orderBillObj = GameObject.Find("OrderBill");

        if (orderBillObj != null)
        {
            orderBillObj.SetActive(true);
        }

        GameObject moneyBasketObj = GameObject.Find("MoneyBasket");

        if (moneyBasketObj != null)
        {
            moneyBasketObj.SetActive(true);
        }
    }
}
