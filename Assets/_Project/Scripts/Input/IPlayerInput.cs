using UnityEngine;

public interface IPlayerInput
{
    Vector2 GetMovementInput();
    Vector2 GetLookInput();
    bool GetJumpInputDown();
    bool GetShootInputDown();
    bool GetADSInputDown();
}
