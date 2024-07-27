using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    public UnityEvent Death;
    public bool invulnerable = false;

    public void InvokeDeath(bool ignoreInvulnerability = false){
        if (ignoreInvulnerability || !invulnerable){
            Death?.Invoke();
        }
    }
}
