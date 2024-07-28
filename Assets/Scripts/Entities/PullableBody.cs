using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullableBody : MonoBehaviour
{
    public Coroutine Pull(Transform where, float speed, float distance){
        var coroutine = PullCoroutine(where, speed, distance);
        return StartCoroutine(coroutine);
    }

    private IEnumerator PullCoroutine(Transform where, float speed, float distance){
        var rigidbody = GetComponent<Rigidbody2D>();
        Vector2 delta = (rigidbody.position - (Vector2)(where.position));
        
        while(delta.magnitude > distance){
            rigidbody.velocity = - delta.normalized * speed;
            yield return new WaitForFixedUpdate();
            delta = (rigidbody.position - (Vector2)(where.position));
        }
    }
}
