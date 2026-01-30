using UnityEngine;
namespace Barongslay.Core.Health
{

    public class PlayerHealth : MonoBehaviour, IDamagable
    {
        public int CurrentHealth { get; set; }
        [SerializeField] int maxHealth = 1;

        public void TakeDamage(int damageAmount)
        {
            CurrentHealth -= damageAmount;
        }
    }
}