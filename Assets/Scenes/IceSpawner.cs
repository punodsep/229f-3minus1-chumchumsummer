using UnityEngine;
using System.Collections;

public class IceSpawner : MonoBehaviour
{
    public GameObject icePrefab;
    public BoxCollider2D spawnArea;

    public float spawnDuration = 5f; // spawn นานกี่วิ
    public float spawnDelay = 0.1f;  // เว้นนิดหน่อยกัน lag (แนะนำ 0.05 - 0.2)

    private bool isSpawning = false;

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            StartCoroutine(SpawnRoutine());
        }
    }

    IEnumerator SpawnRoutine()
    {
        isSpawning = true;

        float timer = 0f;

        while (timer < spawnDuration)
        {
            SpawnIce();

            yield return new WaitForSeconds(spawnDelay); // spawn ถี่ๆ
            timer += spawnDelay;
        }

        isSpawning = false;
    }

    void SpawnIce()
    {
        Bounds bounds = spawnArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        Vector2 spawnPos = new Vector2(x, y);

        Instantiate(icePrefab, spawnPos, Quaternion.identity);
    }
}