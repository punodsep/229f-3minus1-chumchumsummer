using UnityEngine;

public class CustomerButton : MonoBehaviour
{
    public GameObject waitingPanel;

    void Start()
    {
        if (!GameManager.Instance.hasCustomer)
        {
            waitingPanel.SetActive(true);
        }
        else
        {
            waitingPanel.SetActive(false);
        }
    }

    public void SpawnCustomer()
    {
        GameManager.Instance.SpawnCustomer();
        gameObject.SetActive(false);
    }
}