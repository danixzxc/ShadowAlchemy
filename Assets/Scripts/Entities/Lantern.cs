using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lantern : MonoBehaviour
{
    [SerializeField]
    private bool _startingState = true;

    public Sprite spriteOn;
    public Sprite spriteOff;
    public Sprite spriteBroken;
    public LightArea lightArea;
    public Light2D light2D;


    private SpriteRenderer spriteRenderer;
    private bool broken;
    private bool turnedOn;

    public void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        Turn(_startingState);
    }

    public void Break(){
        broken = true;
        turnedOn = false;
        spriteRenderer.sprite = spriteBroken;
        light2D.enabled = false;
        lightArea.enabled = false;
    }

    public void Turn(bool state){
        if(broken) {return;}
        turnedOn = state;
        light2D.enabled = turnedOn;
        lightArea.enabled = turnedOn;
        if(turnedOn){
            spriteRenderer.sprite = spriteOn;
        }
        else{
            spriteRenderer.sprite = spriteOff;
        }
    }

    public void Switch(){
        Turn(!turnedOn);
    }

    public void TurnOn(){
        Turn(true);
    }

    public void TurnOff(){
        Turn(false);
    }
}
