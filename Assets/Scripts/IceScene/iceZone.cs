using UnityEngine;

public class iceZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ice"))
        {
            IceAutoFreeze ice = other.GetComponent<IceAutoFreeze>();
            if (ice != null)
            {
                ice.isInCup = true;

                if (!ice.counted)
                {
                    GameManager.Instance.currentCup.iceAmount++;
                    ice.counted = true;

                    Debug.Log("Ice: " + GameManager.Instance.currentCup.iceAmount);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ice"))
        {
            IceAutoFreeze ice = other.GetComponent<IceAutoFreeze>();
            if (ice != null)
            {
                ice.isInCup = false;

                if (ice.counted)
                {
                    GameManager.Instance.currentCup.iceAmount--;
                    ice.counted = false;
                }
            }
        }
    }
}