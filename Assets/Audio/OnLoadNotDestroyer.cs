using UnityEngine;
using UnityEngine.SceneManagement;
public class OnLoadNotDestroyer : MonoBehaviour
{
    public string ID;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start(){
        DontDestroyOnLoad(this.gameObject);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnLoadNotDestroyer[] objs = FindObjectsByType<OnLoadNotDestroyer>(FindObjectsSortMode.None);
        foreach(var obj in objs){
            if(obj != this && obj.ID == this.ID){
                Destroy(obj.gameObject);
            }
        }
    }
}
