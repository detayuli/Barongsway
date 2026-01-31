using UnityEngine;
using System.Collections;

namespace Barongslay.Core.PlayerInputs
{
    public class PlayerOneInput : PlayerInput
    {
        protected override void HandleJumpInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerMovement.OnJumpInputDown();
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                playerMovement.OnJumpInputUp();
            }
        }

        public override Vector2 DirectionalInput()
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
}