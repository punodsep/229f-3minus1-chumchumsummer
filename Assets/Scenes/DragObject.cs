using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // ตอนเริ่ม = Kinematic
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);

        isDragging = true;

        // 👇 ตอนเริ่มลาก → Dynamic
        rb.bodyType = RigidbodyType2D.Dynamic;

        // กันตก/กันหมุนตอนลาก
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0f;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z) + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        // 👇 เลือกเอาแบบที่ต้องการ

        // แบบที่ 1: ปล่อยแล้วตก (เหมือนโยน)
        rb.gravityScale = 1f;

        // แบบที่ 2: ล็อคกลับเป็น Kinematic
        // rb.bodyType = RigidbodyType2D.Kinematic;
    }
}