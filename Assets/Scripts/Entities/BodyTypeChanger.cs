using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTypeChanger : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    
    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public void ToStatic(){
        rigidbody.bodyType = RigidbodyType2D.Static;
    }
    public void ToDynamic(){
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.WakeUp();
    }
    public void ToKinematic(){
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
}
