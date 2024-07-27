using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDamageDealer : DamageDealer
{
    public float minimalVelocity = 1.0f;

    private new Rigidbody2D rigidbody;

    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void OnCollisionEnter2D(Collision2D collision) 
    {
        if(rigidbody.velocity.magnitude >= minimalVelocity){
            base.OnCollisionEnter2D(collision);
        }
    }
}
