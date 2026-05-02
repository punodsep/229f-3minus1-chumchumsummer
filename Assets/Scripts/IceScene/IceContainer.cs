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

    private void Awake()
    {
        GameObject cupPosObj = GameObject.Find("CupIceScenePos");

        if (cupPosObj == null) return;

        GameObject cup = GameObject.Find("CupManager(Clone)");

        if (cup != null)
        {
            cup.transform.position = cupPosObj.transform.position;
        }

        GameObject orderBillObj = GameObject.Find("OrderBill");

        if (orderBillObj != null)
        {
            orderBillObj.SetActive(false);
        }
    }

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
        SFXManager.Instance.PlaySFX("IceBucket");

        Instantiate(spawnPrefab, spawnPoint.position, Quaternion.identity);

        yield return new WaitForSeconds(respawnTime);

        sr.enabled = true;
        iceContainerOpen.SetActive(false);
        SFXManager.Instance.PlaySFX("IceBucket");

        isCooldown = false;
    }
}