using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [field: SerializeField] public PlayerInput playerInput { get; private set; }//понял что такое field
    public Vector2 RawMovementInput { get; private set; }
    public bool JumpInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;
}
