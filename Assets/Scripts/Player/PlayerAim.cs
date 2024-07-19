using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class PlayerAim : PlayerInput
{
    private Mouse mouse;
    private Gamepad gamepad;

    private Vector2 direction;
    
    public GameObject cursor;

    public UnityEvent<Vector2> DirectionUpdate;


    void Update()
    {
        if (currentControlScheme == "KeyboardMouse"){
            mouse = Mouse.current;
            Assert.IsNotNull(mouse); // IF MOUSE ISNT FOUND THEN SOMETHING FUCKED UP
            Vector3 mousePos = mouse.position.ReadValue();   
            mousePos.z=Camera.main.nearClipPlane;
            Vector3 Worldpos=Camera.main.ScreenToWorldPoint(mousePos);
            direction = (Worldpos - transform.position);
            
        }
        else if (currentControlScheme == "Gamepad"){
            gamepad = Gamepad.current;
            Assert.IsNotNull(gamepad); // IF GAMEPAD ISNT FOUND THEN SOMETHING FUCKED UP
            direction = gamepad.rightStick.ReadValue();
        }
        
        DirectionUpdate?.Invoke(direction);

        //Debug.Log(currentControlScheme);
        //Debug.Log(direction);
        //cursor.transform.position = new Vector3(transform.position.x + direction.x, transform.position.y + direction.y, transform.position.z);
    }
}
