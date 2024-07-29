using UnityEngine;
using UnityEngine.Events;

public class DamageableBody : MonoBehaviour
{
    public UnityEvent<float> OnDamage;
    public UnityEvent OnDeath;


    [SerializeField]
    private float _health = 1;

    public void RecieveDamage(float damage)
    {
        OnDamage?.Invoke(damage);
        _health -= damage;
        if (_health <= 0)
            OnDeath?.Invoke();
    }
}
