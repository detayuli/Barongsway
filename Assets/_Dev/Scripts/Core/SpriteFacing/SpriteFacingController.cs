namespace Barongslay.Core.SpriteFacing
{
    using UnityEngine;
    /// <summary>
    /// Sprite faces the relative of first player position to second player position.
    /// </summary>
    public class SpriteFacingController : MonoBehaviour
    {
        [SerializeField] Transform headPlayerTransform, tailPlayerTransform;
        [SerializeField] Transform thirdPartTransform;
        // [SerializeField] Transform headPlayerSpriteObject, tailPlayerSpriteObject;

        void Update()
        {
            var direction = headPlayerTransform.position.x - tailPlayerTransform.position.x;
            if (direction > 0)
            {
                headPlayerTransform.localScale = new Vector3(1, 1, 1);
                tailPlayerTransform.localScale = new Vector3(1, 1, 1);
                if (thirdPartTransform != null)
                {
                    thirdPartTransform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                headPlayerTransform.localScale = new Vector3(-1, 1, 1);
                tailPlayerTransform.localScale = new Vector3(-1, 1, 1);
                if (thirdPartTransform != null)
                {
                    thirdPartTransform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }

    }
}