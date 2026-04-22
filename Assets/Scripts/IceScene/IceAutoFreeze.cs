using UnityEngine;

public class IceAutoFreeze : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool hasMoved = false;

    [HideInInspector]
    public bool isInFan = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            hasMoved = true;
        }

        if (hasMoved && rb.linearVelocity.magnitude < 0.05f && !isInFan)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}