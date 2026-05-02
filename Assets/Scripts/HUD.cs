using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image customerTimeBar;

    public TextMeshProUGUI gameTimeText;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        var gm = GameManager.Instance;
        if (gm == null) return;

        float fill = gm.currentCustomerTime / gm.customerMaxTime;
        fill = Mathf.Clamp01(fill);

        customerTimeBar.fillAmount = Mathf.Lerp(
            customerTimeBar.fillAmount,
            fill,
            Time.deltaTime * 10f
        );

        UpdateCustomerBarColor(fill);

        gameTimeText.text = gm.GetFormattedGameTime();
        scoreText.text = gm.score.ToString() + " บาท";

        UpdateGameTimeColor(gm.currentGameTime);
    }

    void UpdateCustomerBarColor(float fill)
    {
        if (fill <= 0.2f)
        {
            float t = Mathf.PingPong(Time.time * 5f, 1f);
            customerTimeBar.color = Color.Lerp(Color.red, Color.white, t);
        }
        else
        {
            customerTimeBar.color = Color.white;
        }
    }

    void UpdateGameTimeColor(float time)
    {
        if (time <= 10f)
        {
            float t = Mathf.PingPong(Time.time * 5f, 1f);
            gameTimeText.color = Color.Lerp(Color.black, Color.red, t);
        }
        else if (time <= 30f)
        {
            gameTimeText.color = Color.red;
        }
        else
        {
            gameTimeText.color = Color.black;
        }
    }
}