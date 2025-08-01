using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void doChecks()
    {
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

        player.CheckIfShouldFlip(xInput);

        player.SetVelocity(playerData.movementVelocityX * xInput, playerData.movementVelocityY * yInput);
        
        if (xInput == 0 && yInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}


