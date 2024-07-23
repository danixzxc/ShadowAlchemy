using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RunningState : HorizontalMovementState
{
    public override void FixedUpdate(PlayerMovement playerMovement)
    {
       playerMovement.transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }
}

public class IdleState : HorizontalMovementState
{

    private PlayerMovement _playerMovement;
    public override void EnterState(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
        playerMovement.playerInput.FindActionMap("Player").
            FindAction("StartGame").performed += StartRunning;
    }

    public override void ExitState(PlayerMovement playerMovement)
    {
        playerMovement.playerInput.FindActionMap("Player").
           FindAction("StartGame").performed -= StartRunning;
    }
    private void StartRunning(InputAction.CallbackContext callbackContext)
    {
        _playerMovement.ChangeHorizontalState(_playerMovement.runningState);
    }


}

