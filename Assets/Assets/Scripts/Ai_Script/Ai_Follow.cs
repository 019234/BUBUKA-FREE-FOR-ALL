using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class Ai_Follow : MonoBehaviour
    {
        [Header("Animation")]
        public Animator _anim;

        [Header("Target")]
        public Transform target;

        [Header("Speed")]
        public float moveSpeed = 3.5f;
        public float targetRadius = 1.0f; 

        private UnityEngine.AI.NavMeshAgent navMeshAgent;
        private bool reachedTarget = false;
        private bool isMoving = false;

        void Start()
        {
            navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

         
            navMeshAgent.speed = moveSpeed;
        }

        void Update()
        {
            if (target != null && navMeshAgent != null && !reachedTarget)
            {
                // Set destination
                navMeshAgent.SetDestination(target.position);

                // Check if agent has reached the target
                if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= targetRadius)
                {
                    reachedTarget = true;

                    navMeshAgent.isStopped = true;

                    isMoving = false;
                }

                if(navMeshAgent.velocity.magnitude < 0.1f)
                {
                    isMoving = true;
                }

                if (isMoving)
                {
                    _anim.SetBool("IsWalking", true);
                }
                else
                {
                    _anim.SetBool("IsWalking", false);
                }
            }
        }
    }
}
