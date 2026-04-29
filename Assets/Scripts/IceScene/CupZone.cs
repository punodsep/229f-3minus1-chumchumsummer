using UnityEngine;

public class CupZone : MonoBehaviour
{
    private int icecount = 0;
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
                    icecount++;
                    Debug.Log(icecount);
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