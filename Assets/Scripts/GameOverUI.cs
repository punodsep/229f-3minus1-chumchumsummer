using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        int score = GameManager.Instance.lastScore;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        scoreText.text = "รายได้รวม   " + score + " บาท";
        highScoreText.text = "รายได้สูงสุด   " + highScore + " บาท";
    }
}
