using Barongslay.Core.PlayerLocomotion.StateMachine;
using Barongslay.Core.VictoryDefeat;
using UnityEngine;
namespace Barongslay.Core.Health
{

    public class PlayerDamagable : MonoBehaviour, IDamagable
    {
        public WholeHealthSO CurrentHealth { get => _health; set => _health = value; }
        [SerializeField] WholeHealthSO _health;
        [SerializeField] int _maxHealth;
        [SerializeField] StateContext stateContext;

        void Awake()
        {
            CurrentHealth.Health = _maxHealth;
        }
        public void TakeDamage(int damageAmount)
        {
            CurrentHealth.Health -= damageAmount;
        }
        void Update()
        {
            if (CurrentHealth.Health <= 0 && !stateContext.IsDefeated)
            {
                stateContext.IsDefeated = true;
                VictoryDefeatManager.Instance.RunDefeat();
            }
        }
    }
}