using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _maxHorizontalVelocity;

    public MaxHorizontalVelocity
    {
        get { _maxHorizontalVelocity; }
    }

    [SerializeField]
    private float _runningAcceleration;

    public RunningAcceleration
    {
        get { _runningAcceleration; }
    }
    
    private HorizontalMovementState currentHorizontalMovementState;
    private VerticalMovementState currentVerticalMovementState;
    
    // private SomeVerticalMovementState = new SomeVerticalMovementState();
    // template on how to add states here

    void Start()
    {
        // currentHorizontalMovementState = ... Some starting state
        // currentVerticalMovementState = ... Some starting state
    }

    void FixedUpdate()
    {
        currentVerticalMovementState.FixedUpdate(this);
        currentHorizontalMovementState.FixedUpdate(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        currentVerticalMovementState.OnCollisionEnter(this, collision);
        currentHorizontalMovementState.OnCollisionEnter(this, collision);
        
    }


    public void ChangeVerticalState(VerticalMovementState state)
    {
        currentVerticalMovementState.ExitState(this);
        currentVerticalMovementState = state;
        currentVerticalMovementState.EnterState(this);
    }

    public void ChangeHorizontalState(HorizontalMovementState state)
    {
        currentHorizontalMovementState.ExitState(this);
        currentHorizontalMovementState = state;
        currentHorizontalMovementState.EnterState(this);
    }
}

namespace Movement{

    public abstract class MovementState{
        public abstract void EnterState(PlayerMovement playerMovement);
        public abstract void ExitState(PlayerMovement playerMovement);
        public abstract void FixedUpdate(PlayerMovement playerMovement);
        public abstract void OnCollisionEnter(PlayerMovement playerMovement, Collision collision);
    }

    public abstract class HorizontalMovementState : MovementState{
        
    }

    public abstract class VerticalMovementState : MovementState{
        
    }
}