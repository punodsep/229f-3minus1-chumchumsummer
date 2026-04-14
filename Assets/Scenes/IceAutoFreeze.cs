using UnityEngine;

public class IceAutoFreeze : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool hasMoved = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // เคยเคลื่อนที่จริงไหม
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            hasMoved = true;
        }

        // 👇 เงื่อนไข freeze
        if (hasMoved && rb.linearVelocity.magnitude < 0.05f)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}