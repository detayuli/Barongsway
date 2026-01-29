using UnityEngine;
using System.Collections;

public class PlayerOneInput : PlayerInput
{
    protected override void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.OnJumpInputDown();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            player.OnJumpInputUp();
        }
    }

    protected override Vector2 DirectionalInput()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.A)) // Move left
        {
            horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.D)) // Move right
        {
            horizontal = 1f;
        }

        return new Vector2(horizontal, vertical);
    }
}
