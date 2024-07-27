using UnityEngine;
using UnityEngine.Events;

public class DamageDealer : MonoBehaviour
{
    public UnityEvent OnDamageDealt;
    public UnityEvent OnCollision;
    public float damage = 1.0f;
    protected virtual void OnCollisionEnter2D(Collision2D collision) 
    { 
        var body = collision.collider.GetComponent<DamageableBody>();
        if(body != null){
            body.RecieveDamage(damage);
            OnDamageDealt?.Invoke();
        }
        OnCollision?.Invoke();
    }
}
