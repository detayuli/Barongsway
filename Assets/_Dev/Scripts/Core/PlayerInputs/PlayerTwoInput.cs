using UnityEngine;
using System.Collections;

namespace Barongslay.Core.PlayerInputs
{
    public class PlayerTwoInput : PlayerInput
    {
        protected override void HandleJumpInput()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerMovement.OnJumpInputDown();
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                playerMovement.OnJumpInputUp();
            }
        }

        public override Vector2 DirectionalInput()
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
}