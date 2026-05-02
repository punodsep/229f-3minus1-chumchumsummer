using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;

    public AudioSource bgmSource;
    public AudioClip bgm;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            PlayBGM();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void PlayBGM()
    {
        bgmSource.clip = bgm;
        bgmSource.loop = true;
        bgmSource.Play();
    }
}