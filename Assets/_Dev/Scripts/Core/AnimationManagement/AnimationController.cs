namespace Barongslay.Core.AnimationManagement
{
    using Barongslay.Core.PlayerInputs;
    using Barongslay.Core.PlayerLocomotion.StateMachine;
    using UnityEngine;

    public class AnimationController : MonoBehaviour
    {
        public Animator animator;
        public StateContext stateContext;
        public Rigidbody2D rb;
        public PlayerInput playerInput;
        [SerializeField]
        private WalkGovernor walkGovernor;
        void Update()
        {

            // Ambil nilai absolut kecepatan agar kiri/kanan tetap positif
            float speed;
            switch (walkGovernor)
            {
                case WalkGovernor.UseInput:
                    speed = Mathf.Abs(playerInput.DirectionalInput().x);
                    break;
                case WalkGovernor.UseRigidbody:
                    speed = Mathf.Abs(rb.linearVelocity.x);
                    break;
                default:
                    speed = Mathf.Abs(rb.linearVelocity.x);
                    break;

            }


            if (stateContext.IsGrounded && speed > 0.1f) // Jika bergerak sedikit saja, mainkan walk
            {
                animator.Play("walk");
            }
            if (stateContext.IsGrounded && speed <= 0.1f)
            {

                animator.Play("idle");
            }

        }
    }
    public enum WalkGovernor
    {
        UseRigidbody,
        UseInput
    }
}