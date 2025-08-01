using UnityEngine;
using UnityEngine.Windows;

//создает стейты, обновляет логику и физику текущего стейта, задает X скорость, флип
public class Player : MonoBehaviour
{
    
    public PlayerStateMachine StateMachine { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    [field: SerializeField] public Rigidbody2D RB { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }
    private Vector2 workspace;
    [SerializeField]
    PlayerData playerData;

    public Rigidbody2D modelRb;
    public Vector3 modelDefaultPos;
    public Vector3 tempPos;

    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;
    public bool isGrounded;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        StateMachine.Initialize(IdleState);
        FacingDirection = 1;
    }

    private void Update()
    {
        CurrentVelocity = RB.linearVelocity;
        StateMachine.CurrentState.LogicUpdate();
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);

    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate(); 
    }

    public void SetVelocity(float velocityX, float velocityY)
    {
        workspace.Set(velocityX, velocityY);
        RB.linearVelocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetJumpVelocity()
    {
        modelRb.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmosSelected()
    {
        if (!GroundCheck) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);
    }
}
