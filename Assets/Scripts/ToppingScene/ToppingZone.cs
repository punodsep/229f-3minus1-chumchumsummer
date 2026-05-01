using UnityEngine;

public class ToppingZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("topping"))
        {
            Topping topping = other.GetComponentInParent<Topping>();
            if (topping != null)
            {
                GameObject parentObj = GameObject.Find("ToppingParent");

                if (parentObj != null)
                {
                    topping.transform.SetParent(parentObj.transform, true);
                }

                topping.isInCup = true;

                if (!topping.counted)
                {
                    GameManager.Instance.currentCup.toppingCount++;
                    topping.counted = true;

                    Debug.Log("Topping: " + GameManager.Instance.currentCup.toppingCount);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("topping"))
        {
            Topping topping = other.GetComponentInParent<Topping>();
            if (topping != null)
            {
                topping.isInCup = false;

                if (topping.counted)
                {
                    GameManager.Instance.currentCup.toppingCount--;
                    topping.counted = false;
                }
            }
        }
    }
}
