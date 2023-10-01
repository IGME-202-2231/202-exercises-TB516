using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        _movementController.Direction = ctx.ReadValue<Vector2>();
    }

    public void OnSpacePress(InputAction.CallbackContext ctx)
    {
        SpriteInfo.UseCircleColider = !SpriteInfo.UseCircleColider;
    }
}
