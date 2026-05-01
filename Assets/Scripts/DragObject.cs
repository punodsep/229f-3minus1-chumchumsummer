using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    private Rigidbody2D rb;
    private Vector2 lastPos;

    public float maxAngle = 30f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);

        isDragging = true;

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0.5f;

        lastPos = rb.position;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPos = new Vector2(mousePos.x, mousePos.y) + (Vector2)offset;

            rb.MovePosition(Vector2.Lerp(rb.position, targetPos, 0.2f));

            Vector2 velocity = (rb.position - lastPos) / Time.deltaTime;

            float torque = -velocity.x * 0.03f;
            rb.AddTorque(torque);

            lastPos = rb.position;

            ClampRotation();
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.gravityScale = 1f;
    }

    void ClampRotation()
    {
        float z = transform.eulerAngles.z;

        if (z > 180) z -= 360;

        z = Mathf.Clamp(z, -maxAngle, maxAngle);

        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}