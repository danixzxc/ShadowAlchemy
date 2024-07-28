using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    [SerializeField]
    private DamageType _damageType;
    void OnCollisionEnter2D(Collision2D collision) 
    { 
        PlayerDeath playerDeath = collision.collider.GetComponent<PlayerDeath>();
        if(playerDeath != null){
            playerDeath.InvokeDeath(_damageType);
        }
    }
}
