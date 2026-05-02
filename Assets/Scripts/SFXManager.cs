using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;

    [Header("SFX Clips")]
    public AudioClip click;
    public AudioClip hold;
    public AudioClip callCustomer;
    public AudioClip customer;
    public AudioClip orderBill;
    public AudioClip coin;
    public AudioClip grabObject;
    public AudioClip syrup;
    public AudioClip fanWild;
    public AudioClip shaveIce;
    public AudioClip iceBucket;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySFX(string clipName)
    {
        switch (clipName)
        {
            case "Click":
                PlaySFX(click);
                break;
            case "Hold":
                PlaySFX(hold);
                break;
            case "CallCustomer":
                PlaySFX(callCustomer);
                break;
            case "Customer":
                PlaySFX(customer);
                break;
            case "OrderBill":
                PlaySFX(orderBill);
                break;
            case "Coin":
                PlaySFX(coin);
                break;
            case "GrabObject":
                PlaySFX(grabObject);
                break;
            case "Syrup":
                PlaySFX(syrup);
                break;
            case "FanWind":
                PlaySFX(fanWild);
                break;
            case "ShaveIce":
                PlaySFX(shaveIce);
                break;
            case "IceBucket":
                PlaySFX(iceBucket);
                break;
            default:
                Debug.LogWarning("SFX not found: " + clipName);
                break;
        }
    }

    public void Click()
    {
        PlaySFX("Click");
    }
    public void Hold()
    {
        PlaySFX("Hold");
    }
}