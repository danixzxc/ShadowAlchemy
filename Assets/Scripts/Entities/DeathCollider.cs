using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathCollider : MonoBehaviour
{
    [SerializeField]
    private DamageType _damageType;
    public UnityEvent OnDamageDealt;
    void OnCollisionEnter2D(Collision2D collision) 
    { 
        PlayerDeath playerDeath = collision.collider.GetComponent<PlayerDeath>();
        if(playerDeath != null){
            OnDamageDealt?.Invoke();
            playerDeath.InvokeDeath(_damageType);
        }
    }
}
