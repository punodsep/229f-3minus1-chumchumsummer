using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScroll : MonoBehaviour
{
    public float scrollSpeed = 50f;
    public string homeSceneName = "HomeScene";
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoHome();
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene(homeSceneName);
    }
}
