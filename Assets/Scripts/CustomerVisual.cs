using UnityEngine;
using UnityEngine.UI;

public class CustomerVisual : MonoBehaviour
{
    public Image image;

    public Sprite defaultFace;
    public Sprite happyFace;

    public void SetDefault()
    {
        image.sprite = defaultFace;
    }

    public void SetHappy()
    {
        image.sprite = happyFace;
    }
}