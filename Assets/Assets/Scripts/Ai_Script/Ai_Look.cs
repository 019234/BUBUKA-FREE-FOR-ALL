using UnityEngine;
using UnityEngine.AI;

namespace ItsaMeKen
{
    public class Ai_Look : MonoBehaviour
    {
        public Transform target;
        public float rotationSpeed = 50f;

        void Update()
        {
            if (target != null)
            {
                // Calculate the direction to the target
                Vector3 directionToTarget = target.position - transform.position;

                // Ignore the vertical component to keep the rotation only around the Y-axis
                directionToTarget.y = 0f;

                // Rotate towards the target's right side
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up) * Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}


