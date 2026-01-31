using UnityEngine;


namespace Runtime.Parallax.YSensitive
{

    [ExecuteInEditMode]
    public class ParallaxLayer : MonoBehaviour
    {
        public float parallaxFactor;

        public void Move(Vector3 difference)
        {
            Vector3 newPos = transform.localPosition;
            newPos -= difference * parallaxFactor;

            transform.localPosition = new Vector3(newPos.x, newPos.y, transform.localPosition.z);
        }

    }
}