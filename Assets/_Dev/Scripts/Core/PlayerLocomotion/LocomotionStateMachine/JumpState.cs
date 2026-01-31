
using UnityEngine;

namespace Barongslay.Core.PlayerLocomotion.StateMachine
{
    public class JumpState : State
    {
        public JumpState(StateContext context) : base(context)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            Debug.Log("Exited Jump State");
        }

        public override void Update()
        {
            // if (ctx.IsGrounded)
            // {
            //     ctx.SetState<GroundedState>();
            // }
            if (ctx.rb != null && ctx.rb.linearVelocity.y < 0)
            {
                ctx.SetState<AirborneState>();
            }
        }

    }
}