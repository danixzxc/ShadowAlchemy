using UnityEngine;
using UnityEngine.Events;
public class DamageableTrigger : MonoBehaviour
{
    public UnityEvent OnDamage;

    void OnTriggerEnter2D(Collider2D collider){
        var damageDealer = collider.GetComponent<DamageDealer>();
        if (damageDealer != null && damageDealer.CanDealDamage()){
            OnDamage?.Invoke();
            damageDealer.OnDamageDealt?.Invoke();
        }
    }
}
