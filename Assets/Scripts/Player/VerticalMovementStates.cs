using UnityEngine;
using UnityEngine.InputSystem;

public class OnGroundState : VerticalMovementState
{
    public override void EnterState(PlayerMovement playerMovement)
    {        
        if (playerMovement.IsInHorizontalState(playerMovement.airborneHorizontalState)){
            playerMovement.ChangeHorizontalState(playerMovement.runningState);
        }
    }
    public override void ExitState(PlayerMovement playerMovement)
    {
        if (playerMovement.IsInHorizontalState(playerMovement.runningState)){
            playerMovement.ChangeHorizontalState(playerMovement.airborneHorizontalState);
        }
    }

    public override void FixedUpdate(PlayerMovement playerMovement)
    {
        
        if (!playerMovement.IsGrounded()){
            if (GetVelocityY(playerMovement) >= 0.0f){
                playerMovement.ChangeVerticalState(playerMovement.fallingState);
            }
            else{
                playerMovement.ChangeVerticalState(playerMovement.jumpingState);
            }
        }
    }

}

public class JumpingState : VerticalMovementState
{
    public override void EnterState(PlayerMovement playerMovement)
    {
        //SetVelocityY(playerMovement, playerMovement.JumpVelocity); 
        playerMovement.animator.SetTrigger("ToJump");
    }

    public override void FixedUpdate(PlayerMovement playerMovement)
    {
        SubVelocityY(playerMovement, 9.81f * Time.fixedDeltaTime); // TODO - remove magical number
        if (GetVelocityY(playerMovement) < 0.0f){
            playerMovement.ChangeVerticalState(playerMovement.fallingState);
        }
    }
    public override void ExitState(PlayerMovement playerMovement)
    {      
        playerMovement.animator.ResetTrigger("ToJump");
    }
}

public class FallingState : VerticalMovementState
{
    public override void EnterState(PlayerMovement playerMovement)
    {
        playerMovement.animator.SetTrigger("ToFall");
    }
    public override void FixedUpdate(PlayerMovement playerMovement)
    {
        SubVelocityY(playerMovement, 9.81f * Time.fixedDeltaTime); // TODO - remove magical number
        if (playerMovement.IsGrounded()){
            playerMovement.ChangeVerticalState(playerMovement.onGroundState);
        }
    }
    public override void ExitState(PlayerMovement playerMovement)
    {      
        playerMovement.animator.ResetTrigger("ToFall");
    }
}
