using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBouncer : MonoBehaviour
{
    private SkillsCharacteristics _characteristics;

    public new bool enabled = true; 

    void Start(){
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
    }

    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log(enabled);
        Debug.Log(collider.name);   
        if (! enabled) { return; }
        var player = collider.GetComponent<PlayerMovement>();
        if (player != null){
            if(player.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0.0f){
                var coroutine = SkillCoroutine(player.gameObject.GetComponent<Rigidbody2D>());
                StartCoroutine(coroutine);
            }
            
            
        }
    }

    private IEnumerator SkillCoroutine(Rigidbody2D rigidbody)
    {
        var prev_velocity = rigidbody.velocity;
        rigidbody.velocity = rigidbody.velocity * _characteristics.swordBounceSlowdown;
        yield return new WaitForSeconds(_characteristics.swordBounceDelay);
        rigidbody.velocity = (new Vector2(prev_velocity.x, Mathf.Abs(prev_velocity.y))).normalized * _characteristics.swordBounceSpeed;
    }
}
