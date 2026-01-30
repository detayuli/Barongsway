using UnityEngine;

namespace Barongslay.Core.PlayerLocomotion.RopeConstraint
{
    public class DistanceConstraint : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody2D headPlayer;
        [SerializeField] private Rigidbody2D tailPlayer;

        [Header("Settings")]
        [SerializeField] private float maxDistance = 1.5f;
        [SerializeField] private float pullStrength = 100f; // Kekuatan tarikan tali
        [SerializeField] private float damping = 0.5f;     // Mengurangi efek 'membal' yang berlebihan

        private void FixedUpdate()
        {
            if (headPlayer == null || tailPlayer == null) return;

            // 1. Hitung arah dan jarak antar pemain
            Vector2 direction = tailPlayer.position - headPlayer.position;
            float currentDistance = direction.magnitude;

            // 2. Cek apakah jarak melebihi batas
            if (currentDistance > maxDistance)
            {
                // Hitung seberapa jauh mereka melewati batas
                float error = currentDistance - maxDistance;

                // Normalisasi arah agar kita punya vektor satuan
                Vector2 forceDirection = direction.normalized;

                // 3. Hitung gaya tarik
                // Semakin jauh melebihi batas, semakin kuat tarikannya
                Vector2 force = forceDirection * (error * pullStrength);

                // 4. Berikan gaya ke kedua sisi
                // Head ditarik ke arah Tail
                headPlayer.AddForce(force, ForceMode2D.Force);

                // Tail ditarik ke arah Head (berlawanan arah)
                tailPlayer.AddForce(-force, ForceMode2D.Force);

                // 5. Opsional: Damping (Redaman)
                // Ini membantu menstabilkan objek agar tidak bergetar liar
                ApplyDamping();
            }
        }

        private void ApplyDamping()
        {
            // Mengurangi sedikit kecepatan relatif saat tali menegang
            Vector2 relativeVelocity = tailPlayer.linearVelocity - headPlayer.linearVelocity;
            Vector2 dampingForce = relativeVelocity * damping;

            headPlayer.AddForce(dampingForce, ForceMode2D.Force);
            tailPlayer.AddForce(-dampingForce, ForceMode2D.Force);
        }

        // Visualisasi di Editor agar mudah debugging
        private void OnDrawGizmos()
        {
            if (headPlayer != null && tailPlayer != null)
            {
                Gizmos.color = (Vector2.Distance(headPlayer.position, tailPlayer.position) > maxDistance)
                               ? Color.red : Color.green;
                Gizmos.DrawLine(headPlayer.position, tailPlayer.position);
            }
        }
    }
}