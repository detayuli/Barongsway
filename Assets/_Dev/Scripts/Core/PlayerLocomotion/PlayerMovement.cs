using Barongslay.Core.PlayerLocomotion.StateMachine;
using UnityEngine;
namespace Barongslay.Core.PlayerLocomotion
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;
        [SerializeField] float moveSpeed = 5f;
        [SerializeField] float jumpHeight = 5f;
        [SerializeField] StateContext stateContext;
        float horizontalInput;
        public void SetHorizontalInput(float horizontalInput)
        {
            this.horizontalInput = horizontalInput;
        }
        private void FixedUpdate()
        {
            if (stateContext.FreezeMovement)
            {
                HandleTotalStationary();
                return;
            }
            HandleMovement();
            HandleJump();
        }
        void HandleTotalStationary()
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        void HandleMovement()
        {
            Vector2 velocity = rb.linearVelocity;
            velocity.x = horizontalInput * moveSpeed;
            rb.linearVelocity = velocity;
        }

        bool isJumpPressed = false;
        bool hasJumpedThisFrame = false;

        public void OnJumpInputDown()
        {
            stateContext.JumpPressed = true;
            isJumpPressed = true;
        }

        public void OnJumpInputUp()
        {
            stateContext.JumpPressed = false;
            isJumpPressed = false;
        }

        void HandleJump()
        {
            // Reset flag setiap frame
            hasJumpedThisFrame = false;

            // Hanya execute jump sekali saat input ditekan dan player grounded
            if (isJumpPressed && stateContext.IsGrounded && !hasJumpedThisFrame)
            {
                // float g = Mathf.Abs(Physics.gravity.y);
                // float jumpVelocity = Mathf.Sqrt(2f * g * jumpHeight);

                // rb.linearVelocity = new Vector2(
                //     rb.linearVelocity.x,
                //     jumpVelocity
                // );

                float g = Mathf.Abs(Physics2D.gravity.y * rb.gravityScale);
                float jumpVelocity = Mathf.Sqrt(2f * g * jumpHeight);
                audiomanager.Instance?.PlaySFX(audiomanager.Instance.JumpSound);

                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    jumpVelocity
                );

                hasJumpedThisFrame = true;
                // Consume the input sehingga tidak jump lagi sampai input dilepas dan ditekan lagi
                isJumpPressed = false;
            }
        }
    }
}