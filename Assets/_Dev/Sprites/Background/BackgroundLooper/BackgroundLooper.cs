using System.Collections.Generic;
using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{

    [SerializeField] private List<SpriteRenderer> loopables;
    [SerializeField] private bool loop = true;
    [Tooltip("If not set, will auto reference main camera")]
    [SerializeField] private Camera mainCamera;

    private float spriteWidth;
    private float spriteHeight;

    float camHeight;
    float camWidth;

    float camLeft;
    float camRight;

    float camBottom;
    float camTop;

    void Start()
    {
        if (loopables.Count == 0)
        {
            foreach (Transform child in transform)
            {
                SpriteRenderer sr = child.GetComponentInChildren<SpriteRenderer>();
                if (sr != null)
                    loopables.Add(sr);
            }
        }

        if (mainCamera == null)
            mainCamera = Camera.main;



    }

    void Update()
    {
        if (!loop || loopables.Count == 0 || mainCamera == null)
            return;
        spriteWidth = loopables[0].bounds.size.x;
        spriteHeight = loopables[0].bounds.size.y;

        camHeight = mainCamera.orthographicSize * 2f;
        camWidth = camHeight * mainCamera.aspect;

        camLeft = mainCamera.transform.position.x - camWidth / 2f;
        camRight = mainCamera.transform.position.x + camWidth / 2f;

        camBottom = mainCamera.transform.position.y - camHeight / 2f;
        camTop = mainCamera.transform.position.y + camHeight / 2f;
        foreach (var loopable in loopables)
        {
            // Horizontal loop
            if (loopable.transform.position.x + spriteWidth < camLeft)
            {
                loopable.transform.position += Vector3.right * spriteWidth * loopables.Count;
            }
            else if (loopable.transform.position.x - spriteWidth > camRight)
            {
                loopable.transform.position -= Vector3.right * spriteWidth * loopables.Count;
            }

            // Vertical loop
            if (loopable.transform.position.y + spriteHeight < camBottom)
            {
                loopable.transform.position += Vector3.up * spriteHeight * loopables.Count;
            }
            else if (loopable.transform.position.y - spriteHeight > camTop)
            {
                loopable.transform.position -= Vector3.up * spriteHeight * loopables.Count;
            }
        }
    }


}