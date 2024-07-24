using UnityEngine;
using UnityEngine.InputSystem;

public class OnGroundState : VerticalMovementState
{
    private PlayerMovement _playerMovement; // TODO: Replace this with a better solution
    public override void EnterState(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
        playerMovement.playerInput.FindActionMap("Player").
            FindAction("Jump").performed += ToJump;
    }
    public override void ExitState(PlayerMovement playerMovement)
    {
        playerMovement.playerInput.FindActionMap("Player").
           FindAction("Jump").performed -= ToJump;
    }
    private void ToJump(InputAction.CallbackContext callbackContext)
    {
        _playerMovement.ChangeVerticalState(_playerMovement.jumpingState);
    }
    public override void FixedUpdate(PlayerMovement playerMovement)
    {
        
        if (!playerMovement.IsGrounded()){
            playerMovement.ChangeVerticalState(playerMovement.fallingState);
        }
    }
}

public class JumpingState : VerticalMovementState
{
    public override void EnterState(PlayerMovement playerMovement)
    {
        SetVelocityY(playerMovement, playerMovement.JumpVelocity); 
    }

    public override void FixedUpdate(PlayerMovement playerMovement)
    {
        SubVelocityY(playerMovement, 9.81f * Time.fixedDeltaTime); // TODO - remove magical number
        if (GetVelocityY(playerMovement) < 0.0f){
            playerMovement.ChangeVerticalState(playerMovement.fallingState);
        }
    }

}

public class FallingState : VerticalMovementState
{
    public override void FixedUpdate(PlayerMovement playerMovement)
    {
        SubVelocityY(playerMovement, 9.81f * Time.fixedDeltaTime); // TODO - remove magical number
        if (playerMovement.IsGrounded()){
            playerMovement.ChangeVerticalState(playerMovement.onGroundState);
        }
    }
    
}
