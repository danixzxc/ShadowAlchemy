using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    public UnityEvent Death;

    public void InvokeDeath(){
        Debug.Log("Player Died");
        Death?.Invoke();
    }
}
