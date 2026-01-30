using UnityEngine;

namespace Barongslay.Core.PlayerLocomotion.StateMachine
{
    public class AirborneState : State
    {
        public AirborneState(StateContext context) : base(context)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entered Airborne State");
        }

        public override void Exit()
        {
            Debug.Log("Exited Airborne State");
        }

        public override void Update()
        {
            if (ctx.IsGrounded)
            {
                ctx.SetState<GroundedState>();
            }
        }
    }
}