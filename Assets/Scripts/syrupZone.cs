using UnityEngine;

public class syrupZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("syrup"))
        {
            SyrupDrop syrup = other.GetComponent<SyrupDrop>();
            if (syrup != null)
            {
                syrup.isInCup = true;

                if (!syrup.counted)
                {
                    GameManager.Instance.currentCup.syrupAmount++;
                    syrup.counted = true;

                    Debug.Log("Syrup: " + GameManager.Instance.currentCup.syrupAmount);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("syrup"))
        {
            SyrupDrop syrup = other.GetComponent<SyrupDrop>();
            if (syrup != null)
            {
                syrup.isInCup = false;

                if (syrup.counted)
                {
                    GameManager.Instance.currentCup.syrupAmount--;
                    syrup.counted = false;
                }
            }
        }
    }
}