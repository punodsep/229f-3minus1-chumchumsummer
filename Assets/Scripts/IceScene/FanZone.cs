using UnityEngine;
using System.Collections;

public class FanZone : MonoBehaviour
{
    public float force = 5f;
    public bool isOn = false;

    public float onTime = 2f;
    public float offTime = 2f;

    public ParticleSystem windEffect;

    void Start()
    {
        StartCoroutine(FanRoutine());
    }

    IEnumerator FanRoutine()
    {
        while (true)
        {
            isOn = true;
            windEffect.Play();
            yield return new WaitForSeconds(onTime);

            isOn = false;
            windEffect.Stop();
            yield return new WaitForSeconds(offTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ice"))
        {
            IceAutoFreeze ice = other.GetComponent<IceAutoFreeze>();
            if (ice != null)
            {
                ice.isInFan = true;
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
                ice.isInFan = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!isOn) return;

        if (other.CompareTag("ice"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb == null) return;

            Vector2 windDir = Vector2.left;

            rb.AddForce(windDir * force, ForceMode2D.Force);
        }
    }
}