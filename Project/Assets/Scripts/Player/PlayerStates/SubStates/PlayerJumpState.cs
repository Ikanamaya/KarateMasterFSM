using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class PlayerJumpState : PlayerAbilityState
{

    public bool isJump;

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void doChecks()
    {
        base.doChecks();
        
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseJumpInput();
        player.SetJumpVelocity();
        isAbilityDone = true;
    }
}


//public void Move()
//{
//    float dirX = Input.GetAxisRaw("Horizontal");
//    float dirY = Input.GetAxisRaw("Vertical");

//    if (isGrounded)
//    {
//        mainRb.linearVelocity = new Vector2(dirX, dirY) * 4;

//        tempPos.x = 0;
//        tempPos.y = modelDefaultPos.y;

//        modelRb.transform.localPosition = tempPos;

//        modelRb.linearVelocity = Vector2.zero;
//    }

//    else
//    {
//        mainRb.linearVelocity = new Vector2(dirX, 0) * 4;
//        modelRb.linearVelocity = new Vector2(mainRb.linearVelocity.x, modelRb.linearVelocityY);
//    }
//}
//public void Jump()
//{
//    isGrounded = Physics2D.OverlapCircle(groundChecPos.position, radius, baseLayer);
//    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//    {
//        modelRb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
//        isGrounded = false;
//    }
//}
//}