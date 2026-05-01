using UnityEngine;

public class CustomerButton : MonoBehaviour
{
    public GameObject waitingPanel;
    public GameObject serveButton;

    void Start()
    {
        var gm = GameManager.Instance;
        if (!gm.hasCustomer)
        {
            serveButton.SetActive(false);
            waitingPanel.SetActive(true);
        }
        else
        {
            serveButton.SetActive(gm.canServe && !gm.showResult);
            waitingPanel.SetActive(false);
        }
    }

    public void SpawnCustomer()
    {
        GameManager.Instance.SpawnCustomer();
        gameObject.SetActive(false);
    }
}