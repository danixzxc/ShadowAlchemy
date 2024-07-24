using UnityEngine;

public class SingletonInitializer : MonoBehaviour
{
    void Awake(){
        print(CombinationManager.Instance);
    }
}