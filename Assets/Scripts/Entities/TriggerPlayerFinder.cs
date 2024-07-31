using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerPlayerFinder : MonoBehaviour
{
    public UnityEvent OnPlayerEnter;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("LevelFinished");
            OnPlayerEnter?.Invoke();
        }
    }
}
