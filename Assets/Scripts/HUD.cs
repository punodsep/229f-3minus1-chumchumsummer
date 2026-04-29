using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI customerTimeText;
    public TextMeshProUGUI gameTimeText;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        customerTimeText.text = Mathf.Ceil(GameManager.Instance.currentCustomerTime).ToString();
        gameTimeText.text = Mathf.Ceil(GameManager.Instance.currentGameTime).ToString();
        scoreText.text = GameManager.Instance.score.ToString();
    }
}