using Barongslay.Core.Health;
using UnityEngine;

namespace Barongslay.Core.Obstacles
{
    public class Petasan : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] float countDown = 1f;
        [SerializeField] Obstacle obstacle;

        bool countDownStart = false;
        bool hasExploded = false; // Mencegah pemanggilan ganda

        private void Start()
        {
            animator.Play("petasan_idle");
            obstacle.DoesDamage = false;
        }

        private void Update()
        {
            if (!countDownStart || hasExploded) return;

            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                Explode();
            }
        }

        void Explode()
        {
            hasExploded = true;
            animator.Play("petasan_duar");
            obstacle.DoesDamage = true;
        }

        // Fungsi ini akan dipanggil lewat Animation Event
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        void StartCounting()
        {
            countDownStart = true;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            // Cek jika objek yang masuk memiliki IDamagable
            if (collision.GetComponent<IDamagable>() != null)
            {
                if (!countDownStart)
                {
                    StartCounting();
                }
            }
        }
    }
}