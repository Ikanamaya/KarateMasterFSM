using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerInAirState : PlayerState
{
    private int xInput;
    private bool jumpInput;

    private bool isGrounded;
    private bool isJumping;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void doChecks()
    {
        base.doChecks();
        isGrounded = Physics2D.OverlapCircle(player.GroundCheck.position, player.GroundCheckRadius, player.WhatIsGround);
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;

        //player.RB.linearVelocity = new Vector2(player.CurrentVelocity.x, 0);
        //player.modelRb.linearVelocity = new Vector2(player.RB.linearVelocity.x, player.modelRb.linearVelocityY);
        
        if (isGrounded)
        {
            stateMachine.ChangeState(player.LandState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
