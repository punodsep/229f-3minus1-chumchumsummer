using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToIce() => SceneManager.LoadScene("IceScene");
    public void GoToSyrup() => SceneManager.LoadScene("SyrupScene");
    public void GoToTopping() => SceneManager.LoadScene("ToppingScene");
    public void GoToOrder() => SceneManager.LoadScene("OrderScene");
}