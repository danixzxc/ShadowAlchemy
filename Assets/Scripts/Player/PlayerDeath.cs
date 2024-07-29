using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    public UnityEvent<DamageType> Death;
    public List<DamageType> ImmuneTo = new List<DamageType>();

    public void InvokeDeath(DamageType type, bool ignoreInvulnerability = false)
    {
        if (ignoreInvulnerability || !ImmuneTo.Contains(type))
        {
            Death?.Invoke(type);
        }
    }

    public void InvokeManaDeath(){
        InvokeDeath(DamageType.Light, true);
    }
}
