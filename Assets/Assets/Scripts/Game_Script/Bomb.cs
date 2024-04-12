using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace ItsaMeKen
{
    public class Bomb : MonoBehaviour
    {
        public float explosionForce = 1000f;
        public float explosionRadius = 10f;
        public float fuseDuration = 3f;
        public GameObject explosionEffect;

        public Animator _anim;

        private bool hasExploded = false;

        private CinemachineVirtualCamera cinemachineCamera;

        private void Start()
        {
            cinemachineCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (hasExploded || !collision.gameObject.CompareTag("HandFeet"))
                return;

            _anim.SetBool("Fuse_lit", true);
            StartFuse();

        }

        void StartFuse()
        {
            Invoke("Explode", fuseDuration);
        }

        void Explode()
        {
            if (hasExploded)
                return;

            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }

            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            ShakeCamera();

            Destroy(gameObject);

            hasExploded = true;
        }

        private void ShakeCamera()
        {
            if (cinemachineCamera != null)
            {
                CinemachineBasicMultiChannelPerlin noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                if (noise != null)
                {
                  
                    noise.m_AmplitudeGain = 1.5f;
                    noise.m_FrequencyGain = 2f;

                    
                    StartCoroutine(DecreaseCameraShake(noise));
                }
            }
        }

        private IEnumerator DecreaseCameraShake(CinemachineBasicMultiChannelPerlin noise)
        {
            float duration = 1f;
            float timer = 0f;
            float startAmplitude = noise.m_AmplitudeGain;
            float startFrequency = noise.m_FrequencyGain;

            while (timer < duration)
            {
                float progress = timer / duration;
                noise.m_AmplitudeGain = Mathf.Lerp(startAmplitude, 0f, progress);
                noise.m_FrequencyGain = Mathf.Lerp(startFrequency, 0f, progress);

                timer += Time.deltaTime;
                yield return null;
            }

             
            noise.m_AmplitudeGain = 0f;
            noise.m_FrequencyGain = 0f;
        }
    }
}

