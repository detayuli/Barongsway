using Barongslay.Core.Health;
using UnityEngine;
namespace Barongslay.Core.Obstacles
{
    [RequireComponent(typeof(Collider2D))]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private bool doesDamage = true;
        public bool DoesDamage { get => doesDamage; set => doesDamage = value; }
        private void Start()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        void OnTriggerStay2D(Collider2D collision)
        {
            if (!doesDamage)
            {
                return;
            }
            collision.GetComponent<IDamagable>().TakeDamage(_damage);
        }
    }
}