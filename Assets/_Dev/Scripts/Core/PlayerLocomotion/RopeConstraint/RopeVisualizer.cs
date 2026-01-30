using UnityEngine;

namespace Barongslay.Core.PlayerLocomotion.RopeConstraint
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class RopeVisualizer : MonoBehaviour
    {
        [Header("Connection Anchors")]
        [Tooltip("Titik sambung pada Player A (Kepala)")]
        [SerializeField] private Transform anchorA;

        [Tooltip("Titik sambung pada Player B (Badan/Ekor)")]
        [SerializeField] private Transform anchorB;

        [Header("Visual Settings")]
        [SerializeField] private float spriteWidthInUnits = 1f;
        [SerializeField] private float thickness = 1f; // Menambahkan kontrol ketebalan tali

        private SpriteRenderer spriteRenderer;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void LateUpdate()
        {
            // Validasi jika anchor belum dipasang
            if (anchorA == null || anchorB == null)
            {
                if (spriteRenderer.enabled) spriteRenderer.enabled = false;
                return;
            }

            if (!spriteRenderer.enabled) spriteRenderer.enabled = true;

            UpdateRopeTransform();
        }

        private void UpdateRopeTransform()
        {
            // 1. Ambil posisi aktual dari anchor
            Vector3 posA = anchorA.position;
            Vector3 posB = anchorB.position;

            // 2. Hitung posisi tengah (untuk posisi GameObject tali)
            transform.position = (posA + posB) / 2f;

            // 3. Hitung arah dan jarak
            Vector3 direction = posB - posA;
            float distance = direction.magnitude;

            // 4. Rotasi: Menghadap ke arah anchor B
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // 5. Skala: X untuk panjang, Y untuk ketebalan
            // Kita gunakan ketebalan (thickness) agar tali tidak terlihat penyet saat memanjang
            float scaleX = distance / spriteWidthInUnits;
            transform.localScale = new Vector3(scaleX, thickness, 1f);
        }
    }
}