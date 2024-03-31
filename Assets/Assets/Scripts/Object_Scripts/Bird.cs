using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ItsaMeKen
{

    public class Bird : MonoBehaviour
    {
        public string playerTag = "Player";
        public float _flySpeed = 5f;
        public float _rotationSpeed = 5f;
        public float _detectionRange = 5f;
        public float _destroyDelay = 8f;
        public Transform _targetObject;

        private bool _isFlyingAway = false;
        private Animator _animator;
        private Rigidbody _rb;
        private GameObject _player;

        private float randomOffset; //FUCK YOU FUCK YOU FUCKYUOU

        void Start()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
            _player = GameObject.FindGameObjectWithTag(playerTag);

            randomOffset = Random.Range(0f, 1f);
            _animator.Play("Idle", 0, randomOffset);
        }

        void Update()
        {
            if (!_isFlyingAway)
            {
                if (_player != null && Vector3.Distance(transform.position, _player.transform.position) < _detectionRange)
                {
                    StartFlyingAway();
                    Invoke("DestroyBird", _destroyDelay);
                }
            }
            else
            {
                MoveTowardsTarget();
            }
        }

        void StartFlyingAway()
        {
            _animator.SetTrigger("Run");

            Vector3 targetDirection = (_targetObject.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            _rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime));
            _isFlyingAway = true;
        }

        void MoveTowardsTarget()
        {
            Vector3 targetDirection = (_targetObject.position - transform.position).normalized;
            _rb.MovePosition(transform.position + targetDirection * _flySpeed * Time.deltaTime);
        }

        void DestroyBird()
        {
            Destroy(gameObject);
        }
    }
}