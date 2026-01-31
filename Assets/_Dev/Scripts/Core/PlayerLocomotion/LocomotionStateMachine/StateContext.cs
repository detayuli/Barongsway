using System.Collections.Generic;
using UnityEngine;
namespace Barongslay.Core.PlayerLocomotion.StateMachine
{

    public class StateContext : MonoBehaviour
    {
        public State currentState;
        public Dictionary<System.Type, State> states = new Dictionary<System.Type, State>();
        public Rigidbody2D rb;

        #region State Registration
        private void Awake()
        {
            // Register all states here
            states[typeof(GroundedState)] = new GroundedState(this);
            states[typeof(AirborneState)] = new AirborneState(this);
            states[typeof(JumpState)] = new JumpState(this);
            states[typeof(DeadState)] = new DeadState(this);
            // Add other states similarly
        }
        #endregion

        #region Public Properties
        public bool IsGrounded { get; set; }
        public bool JumpPressed { get; set; }
        public bool FreezeMovement { get; set; }
        public bool IsDefeated { get; set; }
        #endregion

        #region Public Methods
        // public void SetGroundedState(bool grounded = true)
        // {
        //     if (grounded)
        //     {
        //         SetState<GroundedState>();
        //     }
        //     else
        //     {
        //         // If not grounded, set a different state (e.g., AirborneState)
        //         // SetState<AirborneState>();
        //     }
        // }
        #endregion

        void Start()
        {
            // Start in Grounded State
            currentState = states[typeof(GroundedState)];
        }
        public void SetState<T>() where T : State
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = states[typeof(T)];
            currentState.Enter();
        }
        private void Update()
        {
            if (IsDefeated)
            {
                SetState<DeadState>();
            }
            currentState.Update();
        }

    }
}