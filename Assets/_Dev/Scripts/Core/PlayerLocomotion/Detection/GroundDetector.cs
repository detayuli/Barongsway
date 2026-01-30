using Barongslay.Core.PlayerLocomotion.StateMachine;
using UnityEngine;
using System.Collections.Generic;

namespace Barongslay.Core.PlayerLocomotion.Detection
{
    public class GroundDetector : MonoBehaviour
    {
        [Header("Ground Check")]
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float checkDistance = 0.2f;
        [SerializeField] float radius = 0.25f;

        [Header("Check Points")]
        [SerializeField] Transform[] checkPoints;
        [SerializeField] bool useCheckPoints = true;

        [SerializeField] StateContext stateContext;

        private Collider2D playerCollider;

        public bool IsGrounded { get; private set; }
        public int GroundedPointsCount { get; private set; }

        private void Start()
        {
            playerCollider = GetComponent<Collider2D>();
        }

        void FixedUpdate()
        {
            if (useCheckPoints && checkPoints != null && checkPoints.Length > 0)
            {
                PerformMultiPointCheck();
            }
            else
            {
                PerformSinglePointCheck();
            }

            Debug.Log("[GroundDetector] IsGrounded: " + IsGrounded);
            stateContext.IsGrounded = IsGrounded;
        }

        private void PerformSinglePointCheck()
        {
            Vector2 checkPos = (Vector2)transform.position + Vector2.down * checkDistance;
            Collider2D hit = Physics2D.OverlapCircle(checkPos, radius, groundLayer);

            IsGrounded = hit != null && hit != playerCollider;
        }

        private void PerformMultiPointCheck()
        {
            GroundedPointsCount = 0;

            foreach (Transform checkPoint in checkPoints)
            {
                if (checkPoint == null) continue;

                Vector2 checkPos = (Vector2)checkPoint.position + Vector2.down * checkDistance;
                Collider2D hit = Physics2D.OverlapCircle(checkPos, radius, groundLayer);

                if (hit != null && hit != playerCollider)
                {
                    GroundedPointsCount++;
                }
            }

            IsGrounded = GroundedPointsCount > 0;
        }

        public void SetCheckPoints(Transform[] newCheckPoints)
        {
            checkPoints = newCheckPoints;
            useCheckPoints = checkPoints != null && checkPoints.Length > 0;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (useCheckPoints && checkPoints != null)
            {
                foreach (Transform checkPoint in checkPoints)
                {
                    if (checkPoint == null) continue;
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireSphere(checkPoint.position + Vector3.down * checkDistance, radius);
                }
            }
            else
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position + Vector3.down * checkDistance, radius);
            }
        }
#endif
    }
}