using UnityEngine;
using System.Collections;

public class IceContainer : MonoBehaviour
{
    public GameObject spawnPrefab;
    public Transform spawnPoint;
    public GameObject iceContainerOpen;

    public float respawnTime = 2f;

    private bool isCooldown = false;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (isCooldown) return;

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        isCooldown = true;

        sr.enabled = false;
        iceContainerOpen.SetActive(true);

        Instantiate(spawnPrefab, spawnPoint.position, Quaternion.identity);

        yield return new WaitForSeconds(respawnTime);

        sr.enabled = true;
        iceContainerOpen.SetActive(false);

        isCooldown = false;
    }
}