using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPlate : MonoBehaviour
{
    public UnityEvent OnPress;
    public UnityEvent OnRelease;

    public Sprite spriteOn;
    public Sprite spriteOff;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteOff;
    }

    void OnTriggerEnter2D(Collider2D collider){
        ButtonPresser buttonPresser = collider.GetComponent<ButtonPresser>();
        Debug.Log(buttonPresser);
        if(buttonPresser != null && buttonPresser.CanPress){
            Debug.Log("test");
            OnPress?.Invoke();
            spriteRenderer.sprite = spriteOn;
        }
        
    }

    void OnTriggerExit2D(Collider2D collider){
        ButtonPresser buttonPresser = collider.GetComponent<ButtonPresser>();
        if(buttonPresser != null && buttonPresser.CanPress){
            OnRelease?.Invoke();
            spriteRenderer.sprite = spriteOff;
        }
        
    }
}
