using UnityEngine;

public class JarZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("topping"))
        {
            Topping tp = other.GetComponent<Topping>();
            if (tp != null)
            {
                tp.isInJar = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("topping"))
        {
            Topping tp = other.GetComponent<Topping>();
            if (tp != null)
            {
                tp.isInJar = false;
            }
        }
    }
}