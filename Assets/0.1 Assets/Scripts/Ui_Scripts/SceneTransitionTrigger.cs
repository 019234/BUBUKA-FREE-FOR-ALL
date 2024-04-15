using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ItsaMeKen
{
    public class SceneTransitionTrigger : MonoBehaviour
    {
        public GameObject transitionFadeIn;
        public GameObject transitionFadeOut;
        public float transitionDuration = 1.5f;

        private int playersInside = 0;
        private PlayerCounter playerCounter;

        private void Start()
        {
            playerCounter = FindObjectOfType<PlayerCounter>();

            // Ensure both transitions are initially inactive
            transitionFadeIn.SetActive(false);
            transitionFadeOut.SetActive(false);

            // Start the fade-in transition
            StartCoroutine(StartTransition(transitionFadeIn, transitionDuration, TransitionType.FadeIn));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playersInside++;
                Debug.Log("playersInside: " + playersInside);

                if (playersInside == playerCounter.GetPlayerCount())
                {
                    // Start the fade-out transition
                    StartCoroutine(StartTransition(transitionFadeOut, transitionDuration, TransitionType.FadeOut));

                    // Load the next scene after the transition
                    StartCoroutine(LoadNextScene(transitionDuration));
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playersInside = Mathf.Max(0, playersInside - 1);
            }
        }

        private IEnumerator StartTransition(GameObject transitionObject, float duration, TransitionType transitionType)
        {
            transitionObject.SetActive(true);
            Image transitionImage = transitionObject.GetComponent<Image>();
            Color startColor = transitionImage.color;
            Color endColor;

            // Set end color based on transition type
            if (transitionType == TransitionType.FadeIn)
            {
                endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
            }
            else
            {
                endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);
            }

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / duration);
                transitionImage.color = Color.Lerp(startColor, endColor, t);
                yield return null;
            }
            transitionObject.SetActive(false);
        }

        private IEnumerator LoadNextScene(float delay)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // Enumeration for transition types
        private enum TransitionType
        {
            FadeIn,
            FadeOut
        }
    }
}
