using UnityEngine;

public class DebugScript : MonoBehaviour
{
    void Awake(){
        print(RecipeManager.Instance);
    }
}