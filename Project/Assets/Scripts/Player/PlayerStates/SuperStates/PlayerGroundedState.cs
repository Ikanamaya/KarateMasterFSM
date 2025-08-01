using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;

    private bool JumpInput;
    private bool isGrounded;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void doChecks()
    {
        isGrounded = player.isGrounded;
        base.doChecks();
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
        yInput = player.InputHandler.NormInputY;
        JumpInput = player.InputHandler.JumpInput;

        //player.tempPos.x = 0;
        //player.tempPos.y = player.modelDefaultPos.y;
        //player.modelRb.transform.localPosition = player.tempPos;
        //player.modelRb.linearVelocity = Vector2.zero;

        if (JumpInput)
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (!isGrounded)
        {
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
