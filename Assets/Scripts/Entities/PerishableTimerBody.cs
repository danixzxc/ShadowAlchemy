using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerishableTimerBody : MonoBehaviour
{
    [SerializeField]
    private float timeToPerish = 30.0f;

    void Start(){
        Destroy(this.gameObject, timeToPerish);
    }
}
