using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class PlayerAim : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacteristics _playerCharacteristics;
    private Mouse mouse;
    private Gamepad gamepad;

    private Vector2 direction;
    
    public Vector2 offset = Vector2.zero;
    private Vector3 offset3;
    public UnityEvent<Vector2> DirectionUpdate;
    public UnityEvent<Vector2> RawPositionUpdate;
    
    private string currentControlScheme;

    private PlayerInput playerInput;


    void Start(){
        playerInput = GetComponent<PlayerInput>();
        offset3 = new Vector3(offset.x, offset.y, 0.0f);
    }

    void Update()
    {
        currentControlScheme = playerInput.currentControlScheme;
        if (currentControlScheme == "KeyboardMouse")
        {
            mouse = Mouse.current;
            Assert.IsNotNull(mouse); // IF MOUSE ISNT FOUND THEN SOMETHING FUCKED UP
            Vector3 mousePos = mouse.position.ReadValue();   
            mousePos.z=Camera.main.nearClipPlane;
            Vector3 Worldpos=Camera.main.ScreenToWorldPoint(mousePos);
            direction = (Worldpos - transform.position - offset3);
            
        }
        else if (currentControlScheme == "Gamepad")
        {
            gamepad = Gamepad.current;
            Assert.IsNotNull(gamepad); // IF GAMEPAD ISNT FOUND THEN SOMETHING FUCKED UP
            direction = gamepad.rightStick.ReadValue() * _playerCharacteristics.gamepadCursorMaxOffset;
        }        
        DirectionUpdate?.Invoke(direction.normalized);
        RawPositionUpdate?.Invoke(direction);
    }
}
