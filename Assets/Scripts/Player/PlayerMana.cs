using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMana : MonoBehaviour
{
    public UnityEvent<int> MaxManaChanged;
    public UnityEvent<float> ManaChanged;
    public UnityEvent OutOfMana;
    

    [SerializeField]
    private int _max_mana = 1;

    
    public int MaxMana
    {
        get => _max_mana;
        set
        {
            _max_mana = Mathf.Max(value, 1);
            MaxManaChanged?.Invoke(_max_mana);
        }
    }

    private float _mana = 1.0f;
    public float Mana
    {
        get => _mana;
        set
        {
            _mana = Mathf.Min(value, _max_mana);
            if (_mana < 0.0f){
                _mana = 0.0f;
                OutOfMana?.Invoke();
            }
            ManaChanged?.Invoke(_mana);
        }
    }

    void Start(){
        MaxManaChanged?.Invoke(_max_mana);
        Mana = MaxMana;
    }

}
