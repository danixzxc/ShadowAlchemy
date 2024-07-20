using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Load(string scene_name){
        SceneManager.LoadScene(scene_name);
    }
}
