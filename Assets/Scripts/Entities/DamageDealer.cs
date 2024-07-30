using UnityEngine;
using UnityEngine.Events;

public class DamageDealer : MonoBehaviour
{
    public UnityEvent OnDamageDealt;
    public UnityEvent<Collider2D> OnCollision;
    public UnityEvent OnTrigger;
    public float damage = 1.0f;
    protected virtual void OnCollisionEnter2D(Collision2D collision) 
    {
        var body = collision.collider.GetComponent<DamageableBody>();
        if(body != null){
            body.RecieveDamage(damage);
            OnDamageDealt?.Invoke();
        }
        OnCollision?.Invoke(collision.collider);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var body = collision.GetComponent<DamageableBody>();
        if (body != null)
        {
            body.RecieveDamage(damage);
            OnDamageDealt?.Invoke();
        }
        OnTrigger?.Invoke();
    }

    public virtual bool CanDealDamage(){
        return true;
    }
}
