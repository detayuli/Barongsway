using Barongslay.Core.Health;
using UnityEngine;
namespace Barongslay.Core.Obstacles
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Obstacle : MonoBehaviour
    {
        public GameObject gameoverPanel;
        [SerializeField] private int _damage = 1;
        private void Start()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        void OnTriggerEnter2D(Collider2D collision)
        {
            collision.GetComponent<IDamagable>().TakeDamage(_damage);
            gameoverPanel.SetActive(true);
        }
    }
}