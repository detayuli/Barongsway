using UnityEngine;

public class Patrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    
    private Vector3 targetPos;

    void Start()
    {
        // Mulai patroli menuju titik B
        targetPos = pointB.position;
    }

    void Update()
    {
        // Gerakkan musuh menuju target
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Cek jika sudah sampai di target
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            // Tukar target (A ke B, B ke A)
            if (targetPos == pointB.position)
            {
                targetPos = pointA.position;
                Flip(false); // Balik badan ke kiri
            }
            else
            {
                targetPos = pointB.position;
                Flip(true); // Balik badan ke kanan
            }
        }
    }

    void Flip(bool faceRight)
    {
        // Membalik arah sprite agar menghadap ke arah jalan
        if (faceRight)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}