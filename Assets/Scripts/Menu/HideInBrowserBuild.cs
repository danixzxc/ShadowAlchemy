using UnityEngine;

public class HideInBrowserBuild : MonoBehaviour
{
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer){
            gameObject.SetActive(false);
        }
    }
}
