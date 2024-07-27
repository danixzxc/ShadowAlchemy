using UnityEngine;
using UnityEngine.InputSystem;

public class RunningState : HorizontalMovementState
{
    public override void FixedUpdate(PlayerMovement playerMovement)
    {
        if (GetVelocityX(playerMovement) <= playerMovement.MaxHorizontalVelocity){
            AddVelocityX(playerMovement, playerMovement.RunningAcceleration * Time.fixedDeltaTime);
        }
    }

    public override void EnterState(PlayerMovement playerMovement)
    {      
        playerMovement.animator.SetTrigger("ToRun");
    }

    public override void ExitState(PlayerMovement playerMovement)
    {      
        playerMovement.animator.ResetTrigger("ToRun");
    }
}

public class IdleState : HorizontalMovementState
{

    private PlayerMovement _playerMovement; // TODO: Replace this with a better solution
    public override void EnterState(PlayerMovement playerMovement)
    {
        playerMovement.animator.SetTrigger("ToIdle");
        _playerMovement = playerMovement;
        playerMovement.playerInput.FindActionMap("Player").
            FindAction("StartGame").performed += StartRunning;
        
    }

    public override void ExitState(PlayerMovement playerMovement)
    {
        playerMovement.playerInput.FindActionMap("Player").
           FindAction("StartGame").performed -= StartRunning;
        SetVelocityX(playerMovement, playerMovement.StartHorizontalVelocity);
    }
    private void StartRunning(InputAction.CallbackContext callbackContext)
    {
        _playerMovement.ChangeHorizontalState(_playerMovement.runningState);
    }

}

public class AirborneHorizontalState : HorizontalMovementState
{
    
}