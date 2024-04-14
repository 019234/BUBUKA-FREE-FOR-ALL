using UnityEngine;
using UnityEngine.AI;

namespace ItsaMeKen
{
    public class Ai_Follow : MonoBehaviour
    {
        [Header("Animation")]
        public Animator _anim;

        [Header("Target")]
        public string targetTag = "Player"; // Tag of the target GameObject
        public float moveSpeed = 3.5f;

        private Transform target;

        private void Start()
        {
            // Find the target GameObject with the specified tag
            GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);
            if (targetObject != null)
            {
                target = targetObject.transform;
            }
            else
            {
                Debug.LogWarning("Target GameObject with tag '" + targetTag + "' not found.");
            }
        }

        void Update()
        {
            if (target != null)
            {
                // Calculate the direction to the target
                Vector3 directionToTarget = target.position - transform.position;
                directionToTarget.y = 0f; // Ignore vertical component

                // Move towards the target
                transform.position += directionToTarget.normalized * moveSpeed * Time.deltaTime;

                // Check if the AI is moving
                bool isMoving = directionToTarget.magnitude > 0.1f;

                // Set animation state based on movement
                _anim.SetBool("IsWalking", isMoving);
            }
        }
    }
}
