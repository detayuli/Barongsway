namespace Barongslay.Core.PlayerLocomotion.StateMachine
{
    public abstract class State
    {
        protected StateContext ctx;
        protected State(StateContext context)
        {
            ctx = context;
        }
        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}