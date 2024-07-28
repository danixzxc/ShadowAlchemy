using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField]
        private DamageType _damageType;
    void OnTriggerEnter2D(Collider2D collider){
        PlayerDeath playerDeath = collider.GetComponent<PlayerDeath>();
        if(playerDeath != null){
            playerDeath.InvokeDeath(_damageType);
        }
    }
}
