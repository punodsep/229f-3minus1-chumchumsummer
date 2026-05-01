using UnityEngine;

public class SyrupDrop : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool hasMoved = false;

    [HideInInspector] public bool isInCup = false;
    [HideInInspector] public bool counted = false;

    public float destroyTime = 3f;
    private float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0.5f;
        rb.linearDamping = 1.5f;
    }

    void Update()
    {
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            hasMoved = true;
        }

        if (hasMoved && rb.linearVelocity.magnitude < 0.05f)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        if (!isInCup)
        {
            timer += Time.deltaTime;

            if (timer >= destroyTime)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            timer = 0f;
        }
    }
}