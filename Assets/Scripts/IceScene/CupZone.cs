using UnityEngine;

public class CupZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ice"))
        {
            IceAutoFreeze ice = other.GetComponent<IceAutoFreeze>();
            if (ice != null)
            {
                ice.isInCup = true;
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
            }
        }
    }
}