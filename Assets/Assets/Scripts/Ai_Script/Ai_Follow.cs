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

        private UnityEngine.AI.NavMeshAgent navMeshAgent;

        void Start()
        {
            navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        void Update()
        {
            if (target != null && navMeshAgent != null)
            {
                 
                navMeshAgent.SetDestination(target.position);

                 
                bool isMoving = navMeshAgent.velocity.magnitude > 0.1f;

               
                _anim.SetBool("IsWalking", isMoving);
            }
        }
    }
}
