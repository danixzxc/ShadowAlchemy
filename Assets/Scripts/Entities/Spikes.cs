using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public bool stateOnStart = false;
    public SpriteRenderer spriteRenderer;
    public Collider2D trigger;

    public Sprite spriteOn;
    public Sprite spriteOff;
    

    private bool currentState = false;

    void Start(){
        Turn(stateOnStart);
    }

    public void Turn(bool state){
        currentState = state;
        trigger.enabled = state;
        if(state){
            spriteRenderer.sprite = spriteOn;
        }
        else{
            spriteRenderer.sprite = spriteOff;
        }
    }

    public void TurnOn(){
        Turn(true);
    }

    public void TurnOff(){
        Turn(false);
    }

    public void Switch(){
        Turn(!currentState);
    }


    public void TurnOnForTime(float time){
        var coroutine = TimedActivation(time);
        StartCoroutine(coroutine);
    }

    private IEnumerator TimedActivation(float time)
    {
        TurnOn();
        yield return new WaitForSeconds(time);
        TurnOff();
    }

}
