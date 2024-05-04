using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace ItsaMeKen
{
    public class MainMenuWallBlow : MonoBehaviour
    {
        [Header("Main Menu Objects to blow")]
        [SerializeField] private GameObject duckObject;
        [SerializeField] private GameObject explosionObject;
        [SerializeField] private float explosionForce = 100f;
        [SerializeField] private float explosionRadius = 5f;
        [SerializeField] private GameObject wallObject;
        [SerializeField] private GameObject lightObject;
        [SerializeField] private GameObject anotherLightToOff;
        [SerializeField] private GameObject escapeObject;
        [SerializeField] private GameObject defaultLight;
        [SerializeField] private GameObject hanging;
        [SerializeField] private GameObject uiManager;
        [SerializeField] private GameObject eventSystem;

        [SerializeField] private CinemachineVirtualCamera cinemachineCamera;


        [SerializeField] private GameObject space, zero, l3, r3;
       
        [SerializeField] private GameObject j, five, dPadLeft, circle;
        [SerializeField] private GameObject particle;

        [Header("SoundClip")]
        [SerializeField] private AudioClip[] wallExplosionClips;

        [Header("ambience")]
        [SerializeField] private GameObject ambientMusic;
        [SerializeField] private GameObject panickedMusic;





        private void Start()
        {
            
            StartCoroutine(ActivateDuckAndExplosion());
        }

        private IEnumerator ActivateDuckAndExplosion()
        {
            yield return new WaitForSeconds(10f);

            if (duckObject != null)
            {
                duckObject.SetActive(true);
                //To disable
                space.SetActive(false);
                zero.SetActive(false);
                l3.SetActive(false);
                r3.SetActive(false);
                //to enable
                j.SetActive(true);
                five.SetActive(true);
                dPadLeft.SetActive(true);
                circle.SetActive(true);
            }

            yield return new WaitForSeconds(5f);

            if (explosionObject != null)
            {
                explosionObject.SetActive(true);

                // Apply explosion force
                ApplyExplosionForce();
                ShakeCamera();
                SoundFXManager.instance.PlayRandomSoundFXClip(wallExplosionClips, transform, 1f);


                wallObject.SetActive(false);
                lightObject.SetActive(true);

                //Disable the enablers
                j.SetActive(false);
                five.SetActive(false);
                dPadLeft.SetActive(false);
                circle.SetActive(false);
                //Duck
                duckObject.SetActive(false);
                //ability to go back
                escapeObject.SetActive(false);
                eventSystem.SetActive(false);
                uiManager.SetActive(false);
                anotherLightToOff.SetActive(false);

                //LightsObject
                defaultLight.SetActive(false);
                hanging.SetActive(true);
                particle.SetActive(true);

                //Ambience
                ambientMusic.SetActive(false);
                panickedMusic.SetActive(true);

            }
        }

        private void ApplyExplosionForce()
        {
            Collider[] colliders = Physics.OverlapSphere(explosionObject.transform.position, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, explosionObject.transform.position, explosionRadius);
                }
            }
        }

        private void ShakeCamera()
        {
            if (cinemachineCamera != null)
            {
                CinemachineBasicMultiChannelPerlin noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                if (noise != null)
                {
                  
                    noise.m_AmplitudeGain = 2f;
                    noise.m_FrequencyGain = 3f;

                    StartCoroutine(DecreaseCameraShake(noise));
                }
            }
        }

        private IEnumerator DecreaseCameraShake(CinemachineBasicMultiChannelPerlin noise)
        {
            float duration = 2f;
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
