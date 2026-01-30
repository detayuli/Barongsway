using UnityEngine;

namespace Barongslay.Core.PlayerLocomotion.RopeConstraint
{
    // Pastikan ada SpriteRenderer di GameObject ini
    [RequireComponent(typeof(SpriteRenderer))]
    public class RopeVisualizer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform playerA; // Bisa headPlayer
        [SerializeField] private Transform playerB; // Bisa tailPlayer

        [Header("Settings")]
        [SerializeField] private float spriteWidthInUnits = 1f; // Lebar asli sprite tali dalam satuan Unity

        private SpriteRenderer spriteRenderer;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                Debug.LogError("RopeVisualizer requires a SpriteRenderer component!", this);
                enabled = false; // Nonaktifkan script jika tidak ada SpriteRenderer
            }
        }

        void LateUpdate()
        {
            // Pastikan kedua pemain sudah di-assign
            if (playerA == null || playerB == null)
            {
                spriteRenderer.enabled = false; // Sembunyikan tali jika salah satu pemain tidak ada
                return;
            }

            spriteRenderer.enabled = true; // Tampilkan tali

            // 1. Hitung titik tengah antara player A dan B
            Vector3 centerPos = (playerA.position + playerB.position) / 2f;
            transform.position = centerPos;

            // 2. Hitung vektor arah dari A ke B
            Vector3 direction = playerB.position - playerA.position;

            // 3. Hitung jarak antara A dan B
            float distance = direction.magnitude;

            // 4. Atur rotasi tali agar menunjuk dari A ke B
            // Menghitung sudut dalam radian, lalu konversi ke derajat
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // 5. Atur skala X agar sprite membentang sesuai jarak
            // Kita perlu membagi jarak dengan lebar asli sprite
            if (spriteWidthInUnits <= 0) // Hindari pembagian dengan nol
            {
                Debug.LogWarning("Sprite Width In Units must be greater than 0!", this);
                return;
            }

            transform.localScale = new Vector3(distance / spriteWidthInUnits, 1f, 1f); // Skala Y dan Z tetap 1
        }
    }
}