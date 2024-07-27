using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [HideInInspector]
    public new Rigidbody2D rigidbody;
    [HideInInspector]
    public Animator animator;

    [SerializeField]
    private PlayerCharacteristics _playerCharacteristics;

    public float StartHorizontalVelocity
    {
        get
        {
            return _playerCharacteristics.startHorizontalVelocity;
        }
    }
    public float MaxHorizontalVelocity
    {
        get
        {
            return _playerCharacteristics.maxHorizontalVelocity;
        }
    }


    public float RunningAcceleration
    {
        get
        {
            return _playerCharacteristics.runningAcceleration;
        }
    }

    [SerializeField]
    private LayerMask _groundLayer;


    [SerializeField]
    public InputActionAsset playerInput;

    private HorizontalMovementState currentHorizontalMovementState = new HorizontalMovementState();
    private VerticalMovementState currentVerticalMovementState = new VerticalMovementState();

    // Horizontal States:
    public RunningState runningState = new RunningState();
    public IdleState idleState = new IdleState();
    public AirborneHorizontalState airborneHorizontalState = new AirborneHorizontalState();
    // Vertical States:
    public OnGroundState onGroundState = new OnGroundState();
    public JumpingState jumpingState = new JumpingState();
    public FallingState fallingState = new FallingState();

    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ChangeHorizontalState(idleState);
        ChangeVerticalState(fallingState);
        
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

    public bool IsInHorizontalState(HorizontalMovementState state){
        return currentHorizontalMovementState == state;
    }

    public bool IsInVerticalState(VerticalMovementState state){
        return currentVerticalMovementState == state;
    }

    public bool IsGrounded() {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.33f;
        
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, _groundLayer);
        if (hit.collider != null) {
            return true;
        }
        
        return false;
    }

    public bool TouchingWall()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.right;
        float distance = 0.33f;

        RaycastHit2D hit = Physics2D.BoxCast(position + new Vector2(0.0f, 1.0f), 
            new Vector2(1.0f, 2.0f), 0.0f, Vector2.right, distance, _groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
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
    protected void SetVelocityX(PlayerMovement playerMovement, float velocity){
        playerMovement.rigidbody.velocity = new Vector2(velocity, playerMovement.rigidbody.velocity.y);
    }

    protected float GetVelocityX(PlayerMovement playerMovement){
        return playerMovement.rigidbody.velocity.x;
    }
    protected void AddVelocityX(PlayerMovement playerMovement, float velocity){
        playerMovement.rigidbody.velocity = new Vector2(playerMovement.rigidbody.velocity.x + velocity, playerMovement.rigidbody.velocity.y);
    }
    protected void SubVelocityX(PlayerMovement playerMovement, float velocity){
        playerMovement.rigidbody.velocity = new Vector2(playerMovement.rigidbody.velocity.x - velocity, playerMovement.rigidbody.velocity.y);
    }
}

public class VerticalMovementState : MovementState
{
    protected void SetVelocityY(PlayerMovement playerMovement, float velocity){
        playerMovement.rigidbody.velocity = new Vector2(playerMovement.rigidbody.velocity.x, velocity);
    }

    protected float GetVelocityY(PlayerMovement playerMovement){
        return playerMovement.rigidbody.velocity.y;
    }
    protected void AddVelocityY(PlayerMovement playerMovement, float velocity){
        playerMovement.rigidbody.velocity = new Vector2(playerMovement.rigidbody.velocity.x, playerMovement.rigidbody.velocity.y + velocity);
    }
    protected void SubVelocityY(PlayerMovement playerMovement, float velocity){
        playerMovement.rigidbody.velocity = new Vector2(playerMovement.rigidbody.velocity.x, playerMovement.rigidbody.velocity.y - velocity);
    }
}