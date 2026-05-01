using UnityEngine;

public class Topping : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool hasMoved = false;

    [HideInInspector] public bool isInCup = false;
    [HideInInspector] public bool isInJar = false;
    [HideInInspector] public bool counted = false;

    DragObject drag;

    public float destroyTime = 5f;
    private float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        drag = GetComponent<DragObject>();
    }

    void Update()
    {
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            hasMoved = true;
        }

        if (hasMoved && rb.linearVelocity.magnitude < 0.05f && isInCup && !isInJar && !drag.isDragging)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
            //drag.enabled = false;
        }

        if (!isInCup && !isInJar && !drag.isDragging)
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