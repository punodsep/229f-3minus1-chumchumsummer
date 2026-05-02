using UnityEngine;

public class JarZone : MonoBehaviour
{
    private void Awake()
    {
        GameObject cupPosObj = GameObject.Find("CupToppingScenePos");

        if (cupPosObj == null) return;

        GameObject cup = GameObject.Find("CupManager(Clone)");

        if (cup != null)
        {
            cup.transform.position = cupPosObj.transform.position;
        }
    }

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