namespace Barongslay.Core.PlayerLocomotion.StateMachine
{
    public class DeadState : State
    {
        public DeadState(StateContext context) : base(context)
        {
        }

        public override void Enter()
        {
            ctx.FreezeMovement = true;
            ctx.IsDefeated = true;
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
        }
    }
}