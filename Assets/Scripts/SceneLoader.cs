using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToIce()
    {
        SceneManager.LoadScene("IceScene");

        GameObject cupPosObj = GameObject.Find("CupIceScenePos");

        if (cupPosObj == null) return;

        GameObject cup = GameObject.Find("CupManager(Clone)");

        if (cup != null)
        {
            cup.transform.position = cupPosObj.transform.position;
        }
    }
    public void GoToSyrup()
    {
        SceneManager.LoadScene("SyrupScene");

        GameObject cupPosObj = GameObject.Find("CupSyrupScenePos");

        if (cupPosObj == null) return;

        GameObject cup = GameObject.Find("CupManager(Clone)");

        if (cup != null)
        {
            cup.transform.position = cupPosObj.transform.position;
        }
    }
    public void GoToTopping()
    {
        SceneManager.LoadScene("ToppingScene");

        GameObject cupPosObj = GameObject.Find("CupToppingScenePos");

        if (cupPosObj == null) return;

        GameObject cup = GameObject.Find("CupManager(Clone)");

        if (cup != null)
        {
            cup.transform.position = cupPosObj.transform.position;
        }
    }
    public void GoToServe()
    {
        GameManager.Instance.canServe = true;
        SceneManager.LoadScene("OrderScene");

        GameObject cupPosObj = GameObject.Find("CupOrderScenePos");

        if (cupPosObj == null) return;

        GameObject cup = GameObject.Find("CupManager(Clone)");

        if (cup != null)
        {
            cup.transform.position = cupPosObj.transform.position;
        }
    }

    public void GoToGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("OrderScene");
    }

    public void GotoMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("MenuScene");
    }

    public void GoToCredit()
    {
        SceneManager.LoadScene("CreditScene");
    }
}