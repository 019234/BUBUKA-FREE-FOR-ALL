using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class SoundFXManager : MonoBehaviour
    {
        public static SoundFXManager instance;

        [SerializeField] private AudioSource soundFXObject;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

        }

        public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
        {
            AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

            audioSource.clip = audioClip;

            audioSource.pitch = UnityEngine.Random.Range(1f, 1.5f);

            audioSource.volume = volume;

            audioSource.Play();

            float cliplength = audioSource.clip.length;

            Destroy(audioSource.gameObject, cliplength);
        }

        public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
        {
            int rand = Random.Range(0, audioClip.Length);

            AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

            audioSource.clip = audioClip[rand];

            audioSource.pitch = UnityEngine.Random.Range(1f, 1.5f);

            audioSource.volume = volume;

            audioSource.Play();

            float cliplength = audioSource.clip.length;

            Destroy(audioSource.gameObject, cliplength);
        }

    }
}
