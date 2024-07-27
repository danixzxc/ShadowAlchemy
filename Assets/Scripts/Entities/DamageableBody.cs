using UnityEngine;
using UnityEngine.Events;

public class DamageableBody : MonoBehaviour
{
    public UnityEvent<float> OnDamage;

    public void RecieveDamage(float damage){
        OnDamage?.Invoke(damage);
    }    
}
