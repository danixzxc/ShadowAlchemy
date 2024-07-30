using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private bool _enabled = true;
    public new bool enabled{
        get {return _enabled;}
        set {
            _enabled = value;
            if (_enabled){
                spriteRenderer.sprite = spriteOn;
            }
            else{
                time = 0.0f;
                spriteRenderer.sprite = spriteOff;
            }
        }
    }


    public float cooldown;  
    public Transform spawningPoint;
    private float time;
    public float angle = -180;

    public GameObject prefab;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteOn;
    public Sprite spriteOff;
    

    void Update(){
        if (!enabled) {
            return;
        }
        time += Time.deltaTime;
        if (time >= cooldown){
            time -= cooldown;
            GameObject fireball = Instantiate(prefab, spawningPoint);
            fireball.GetComponent<Fireball>().SetAngle(angle);
        }
    }

    public void Turn(bool state){
        enabled = state;
    }

    public void TurnOn(){
        Turn(true);
    }

    public void TurnOff(){
        Turn(false);
    }

    public void Switch(){
        Turn(!enabled);
    }
}
