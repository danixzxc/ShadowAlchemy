using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    private new Rigidbody2D rigidbody;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

    }
}
