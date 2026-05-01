using UnityEngine;

public class SyrupShooter : MonoBehaviour
{
    public GameObject syrupPrefab;
    public Transform shootPoint;
    public Transform parent;

    public float shootForce = 3f;
    public float fireRate = 0.05f;
    public float spread = 0.15f;

    private float timer = 0f;
    private bool isHolding = false;

    void Update()
    {
        if (isHolding)
        {
            timer += Time.deltaTime;

            if (timer >= fireRate)
            {
                Shoot();
                timer = 0f;
            }
        }
    }

    void OnMouseDown()
    {
        isHolding = true;
    }

    void OnMouseUp()
    {
        isHolding = false;
    }

    void Shoot()
    {
        GameObject s = Instantiate(syrupPrefab, shootPoint.position, Quaternion.identity);
        GameObject parentObj = GameObject.Find("SyrupParent");

        if (parentObj != null)
        {
            s.transform.SetParent(parentObj.transform, true);
        }

        Rigidbody2D rb = s.GetComponent<Rigidbody2D>();

        Vector2 dir = shootPoint.up;

        dir.y += 0.5f;

        float angle = Random.Range(-spread, spread);
        dir = Quaternion.Euler(0, 0, angle) * dir;

        dir.Normalize();

        float vx = dir.x * shootForce;
        float vy = dir.y * shootForce;

        rb.linearVelocity = new Vector2(vx, vy);
    }
}