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

    private Vector2 direction = Vector2.right;
    
    public Vector2 offset = Vector2.zero;
    private Vector3 offset3;
    public UnityEvent<Vector2> DirectionUpdate;
    public UnityEvent<Vector2> RawPositionUpdate;
    public UnityEvent<float> AngleUpdate;
    private string currentControlScheme;

    private PlayerInput playerInput;

    public float gamepadDeadzone = 0.3f;


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
            Vector3 mousePos = mouse.position.ReadValue();   
            mousePos.z=Camera.main.nearClipPlane;
            Vector3 Worldpos=Camera.main.ScreenToWorldPoint(mousePos);
            direction = (Worldpos - transform.position - offset3);
            
        }
        else if (currentControlScheme == "Gamepad")
        {
            gamepad = Gamepad.current;
            //Assert.IsNotNull(gamepad); // IF GAMEPAD ISNT FOUND THEN SOMETHING FUCKED UP
            Vector2 left = gamepad.leftStick.ReadValue();
            if (left.magnitude < gamepadDeadzone){
                left = Vector2.zero;
            }
            if (left == Vector2.zero){
                Vector2 right = gamepad.rightStick.ReadValue();
                if (right.magnitude < gamepadDeadzone){
                    right = Vector2.zero;
                }
                if (right == Vector2.zero){
                    // Nothing, leave direction since prev frame
                } else{
                    direction = right * _playerCharacteristics.gamepadCursorMaxOffset;
                }
            }
            else {
                direction = left * _playerCharacteristics.gamepadCursorMaxOffset;
            }
        }        
        DirectionUpdate?.Invoke(direction.normalized);
        RawPositionUpdate?.Invoke(direction);
        AngleUpdate?.Invoke(CalculateAngle(direction));
    }

    float CalculateAngle(Vector2 _direction){
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        if(angle > 0.0f){
            return Mathf.Min(_playerCharacteristics.maxUpperAngle, angle);
        }
        else{
            return Mathf.Max(-_playerCharacteristics.maxLowerAngle, angle);
        }
    }
}
