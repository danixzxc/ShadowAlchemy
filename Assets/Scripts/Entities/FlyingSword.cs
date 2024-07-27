using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSword : DamageDealer
{
    public PlayerBouncer bouncer;
    public LayerMask _groundLayer; 
    private bool flying = true;

    private new Rigidbody2D rigidbody;

    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        flying = true;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        bouncer.enabled = false;
    }

    protected override void OnCollisionEnter2D(Collision2D collision) 
    {
        if(flying){
            base.OnCollisionEnter2D(collision);

            if(((1 << collision.collider.gameObject.layer) & _groundLayer.value) != 0){
                flying = false;
                var rigidbody = GetComponent<Rigidbody2D>();
                rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                bouncer.enabled = true;
            }
        }
        else{
            
        }
    }
}
