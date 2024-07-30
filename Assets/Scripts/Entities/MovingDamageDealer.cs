using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDamageDealer : DamageDealer
{
    public float minimalVelocity = 1.0f;

    private new Rigidbody2D rigidbody;
    private Vector2 _lastVelocity;
    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void OnCollisionEnter2D(Collision2D collision) 
    {
        if(_lastVelocity.magnitude >= minimalVelocity){
            base.OnCollisionEnter2D(collision);
        }
    }

    public override bool CanDealDamage(){
        return rigidbody.velocity.magnitude >= minimalVelocity;
    }

    void FixedUpdate(){
        _lastVelocity = rigidbody.velocity;
    }
}
