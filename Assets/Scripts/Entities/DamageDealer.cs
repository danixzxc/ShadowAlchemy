using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damage = 1.0f;
    protected virtual void OnCollisionEnter2D(Collision2D collision) 
    { 
        var body = collision.collider.GetComponent<DamageableBody>();
        if(body != null){
            body.RecieveDamage(damage);
        }
    }
}
