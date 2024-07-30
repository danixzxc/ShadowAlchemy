using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    private Rigidbody2D rigidbody;

    void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        rigidbody.velocity = speed * direction; 
    }

    public void SetAngle(float angle){
        rigidbody.rotation = angle;
        direction = Skill.AngleToVec2(angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        //fireball pop animation
        Debug.Log("Fireball pop");
    }
}
