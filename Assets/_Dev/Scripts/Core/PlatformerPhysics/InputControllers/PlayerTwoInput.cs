using UnityEngine;
using System.Collections;

public class PlayerTwoInput : PlayerInput
{
    protected override void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.OnJumpInputDown();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            player.OnJumpInputUp();
        }
    }

    protected override Vector2 DirectionalInput()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.LeftArrow)) // Move left
        {
            horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Move right
        {
            horizontal = 1f;
        }

        return new Vector2(horizontal, vertical);
    }
}
