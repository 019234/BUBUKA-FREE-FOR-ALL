using UnityEngine;
using UnityEngine.AI;

namespace ItsaMeKen
{
    public class Ai_Follow : MonoBehaviour
    {
        [Header("Animation")]
        public Animator _anim;

        [Header("Target")]
        public string targetTag = "Player"; 
        public float moveSpeed = 3.5f;

        private Transform target;

        private void Start()
        {
            
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
                
                Vector3 directionToTarget = target.position - transform.position;
                directionToTarget.y = 0f; 

            
                transform.position += directionToTarget.normalized * moveSpeed * Time.deltaTime;

            
                bool isMoving = directionToTarget.magnitude > 0.1f;

               
                _anim.SetBool("IsWalking", isMoving);
            }
        }
    }
}
