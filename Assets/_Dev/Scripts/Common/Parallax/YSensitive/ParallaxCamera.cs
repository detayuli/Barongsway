using UnityEngine;

namespace Runtime.Parallax.YSensitive
{
    [ExecuteInEditMode]
    public class ParallaxCamera : MonoBehaviour
    {
        public delegate void ParallaxCameraDelegate(Vector3 vectorDifference);
        public ParallaxCameraDelegate onCameraTranslate;

        private Vector3 oldPosition;

        void Start()
        {
            oldPosition = transform.position;
        }

        void Update()
        {
            if (transform.position != oldPosition)
            {
                if (onCameraTranslate != null)
                {
                    var delta = oldPosition - transform.position;
                    onCameraTranslate(delta);
                }

                oldPosition = transform.position;
            }
        }
    }
}