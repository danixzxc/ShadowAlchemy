using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public new Rigidbody2D rigidbody;

    [SerializeField]
    private float _maxHorizontalVelocity;

    public float MaxHorizontalVelocity
    {
        get
        {
            return _maxHorizontalVelocity;
        }
    }

    [SerializeField]
    private float _runningAcceleration;

    public float RunningAcceleration
    {
        get
        {
            return _runningAcceleration;
        }
    }

    [SerializeField]
    public InputActionAsset playerInput;

    private HorizontalMovementState currentHorizontalMovementState;
    private VerticalMovementState currentVerticalMovementState = new VerticalMovementState();

    // private SomeVerticalMovementState = new SomeVerticalMovementState();
    public RunningState runningState = new RunningState();
    public IdleState idleState = new IdleState();
    // template on how to add states here

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ChangeHorizontalState(idleState);
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
        currentVerticalMovementState?.ExitState(this);
        currentVerticalMovementState = state;
        currentVerticalMovementState.EnterState(this);
    }

    public void ChangeHorizontalState(HorizontalMovementState state)
    {
        currentHorizontalMovementState?.ExitState(this);
        currentHorizontalMovementState = state;
        currentHorizontalMovementState.EnterState(this);
    }

}

public class MovementState
{
    public virtual void EnterState(PlayerMovement playerMovement){}
    public virtual void ExitState(PlayerMovement playerMovement){}
    public virtual void FixedUpdate(PlayerMovement playerMovement){}
    public virtual void OnCollisionEnter(PlayerMovement playerMovement, Collision collision){}
   
    //public virtual void Event(PlayerMovement playerMovement, Event event);
}

public class HorizontalMovementState : MovementState
{

}

public class VerticalMovementState : MovementState
{


}