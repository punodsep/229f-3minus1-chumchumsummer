using UnityEngine;

public class IceCollision : MonoBehaviour
{
    public IceSpawner spawner;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ice"))
        {
            Destroy(other.gameObject);

            spawner.StartSpawning();
        }
    }
}