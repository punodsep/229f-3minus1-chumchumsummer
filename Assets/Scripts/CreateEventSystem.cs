using UnityEngine;
using UnityEngine.EventSystems;

public class CreateEventSystem : MonoBehaviour
{
    void Awake()
    {
        var existing = FindObjectsByType<EventSystem>(FindObjectsSortMode.None);

        if (existing.Length == 0)
        {
            GameObject es = new GameObject("EventSystem");
            es.AddComponent<EventSystem>();
            es.AddComponent<StandaloneInputModule>();

            DontDestroyOnLoad(es);
        }
    }
}