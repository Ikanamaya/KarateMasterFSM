using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private int xInput;
    private int yInput;

    private bool ShouldCheckFlip;
    public Animator Anim { get; private set; }
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

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

        if (ShouldCheckFlip)
        {
            player.CheckIfShouldFlip(xInput);
        }
    }

    public void SetFlipCheck(bool value)
    {
        ShouldCheckFlip = value;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }
}
