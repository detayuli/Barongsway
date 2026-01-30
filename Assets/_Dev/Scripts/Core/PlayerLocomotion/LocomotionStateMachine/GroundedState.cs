using Unity.VisualScripting;
using UnityEngine;
namespace Barongslay.Core.PlayerLocomotion.StateMachine
{

    public class GroundedState : State
    {
        public GroundedState(StateContext context) : base(context)
        {
        }
        public override void Enter()
        {
            Debug.Log("Entered Grounded State");
        }

        public override void Exit()
        {
            Debug.Log("Exited Grounded State");
        }

        public override void Update()
        {
            if (!ctx.IsGrounded)
            {
                ctx.SetState<AirborneState>();
                return;
            }

            if (ctx.JumpPressed)
            {
                ctx.SetState<JumpState>();
                return;
            }
        }
    }
}