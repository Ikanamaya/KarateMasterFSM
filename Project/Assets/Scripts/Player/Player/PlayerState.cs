using UnityEngine;

public class PlayerState//базовый класс для стейтов: конструктор + логика для стейтов
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;

    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        doChecks();
        startTime = Time.time;
        player.Anim.SetBool(animBoolName, true); //можно изменять параметры
        Debug.Log(animBoolName);
        isAnimationFinished = false;
        isExitingState = false;

    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        doChecks();
    }

    public virtual void doChecks() { }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
