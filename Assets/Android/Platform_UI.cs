
    using UnityEngine;

public class PlatformUI : MonoBehaviour
{
    public GameObject androidUI;

    void Start()
    {
#if UNITY_ANDROID
        androidUI.SetActive(true);
#else
        androidUI.SetActive(false);
#endif
    }
}


