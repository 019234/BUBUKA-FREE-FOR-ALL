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

        private float randomOffset;
        private bool _finishedClip;

        [Header("Sound")]
        [SerializeField] private AudioClip[] idleClips;
        [SerializeField] private AudioClip[] runningAwayClips;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();

            StartCoroutine(FindPlayerWithTagAfterDelay(0.1f));
            InvokeRepeating("ResetFinishedClip", Random.Range(0f, 10f), Random.Range(5f, 15f));

            randomOffset = Random.Range(0f, 1f);
            _animator.Play("Idle", 0, randomOffset);
        }

        IEnumerator FindPlayerWithTagAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _player = GameObject.FindGameObjectWithTag(playerTag);
        }

        void Update()
        {
            if (!_isFlyingAway && _player != null && Vector3.Distance(transform.position, _player.transform.position) < _detectionRange)
            {
                StartFlyingAway();
                Invoke("DestroyBird", _destroyDelay);
                SoundFXManager.instance.PlayRandomSoundFXClip(runningAwayClips, transform, 1f);
            }
            else if (_isFlyingAway)
            {
                MoveTowardsTarget();
            }

            if (!_finishedClip)
            {
                SoundFXManager.instance.PlayRandomSoundFXClip(idleClips, transform, 1f);
                _finishedClip = true;
            }
        }

        private void ResetFinishedClip()
        {
            _finishedClip = false;
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
