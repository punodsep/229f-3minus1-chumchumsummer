using UnityEngine;
using UnityEngine.EventSystems;

public class UISFXSimple : MonoBehaviour,
    IPointerEnterHandler,
    IPointerClickHandler
{
    public string hoverSFX = "Hold";
    public string clickSFX = "Click";

    public void OnPointerEnter(PointerEventData eventData)
    {
        Play(hoverSFX);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Play(clickSFX);
    }

    void Play(string sfxName)
    {
        if (SFXManager.Instance != null)
        {
            SFXManager.Instance.PlaySFX(sfxName);
        }
    }
}