using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ItsaMeKen
{
    public class EliminationEnding : MonoBehaviour
    {
        private bool p1 = false;
        private bool p2 = false;
        private bool p3 = false;
        private bool p4 = false;

        public GameObject blur;

        public GameObject win1;
        public GameObject win2;
        public GameObject win3;
        public GameObject win4;

        public GameObject transitionFadeIn;
        public GameObject transitionFadeOut;
        public float transitionDuration = 1.5f;

        private void Start()
        {

            transitionFadeIn.SetActive(true);


            StartCoroutine(StartTransition(transitionFadeIn, transitionDuration, TransitionType.FadeIn));
        }

        void Update()
        {
            UpdatePlayerStates();
            CheckWinConditions();
        }

        private void UpdatePlayerStates()
        {
            HeadP1 headP1 = FindObjectOfType<HeadP1>();
            if (headP1 != null)
            {
                p1 = headP1.IsAlive();
            }
            else
            {
                p1 = false;
            }

            HeadP2 headP2 = FindObjectOfType<HeadP2>();
            if (headP1 != null)
            {
                p2 = headP2.IsAlive();
            }
            else
            {
                p2 = false;
            }


            HeadP3 headP3 = FindObjectOfType<HeadP3>();
            if (headP3 != null)
            {
                p3 = headP3.IsAlive();
            }
            else
            {
                p3 = false;
            }


            HeadP4 headP4 = FindObjectOfType<HeadP4>();
            if (headP4 != null)
            {
                p4 = headP4.IsAlive();
            }
            else
            {
                p4 = false;
            }

        }

        private void CheckWinConditions()
        {
            if (p1 && !p2 && !p3 && !p4)
            {
                win1.SetActive(true);
                blur.SetActive(true);
                StartFadeOutTransition();
            }
            else if (!p1 && p2 && !p3 && !p4)
            {
                win2.SetActive(true);
                blur.SetActive(true);
                StartFadeOutTransition();
            }
            else if (!p1 && !p2 && p3 && !p4)
            {
                win3.SetActive(true);
                blur.SetActive(true);
                StartFadeOutTransition();
            }
            else if (!p1 && !p2 && !p3 && p4)
            {
                win4.SetActive(true);
                blur.SetActive(true);
                StartFadeOutTransition();
            }
        }

        private void StartFadeOutTransition()
        {
            StartCoroutine(StartTransition(transitionFadeOut, transitionDuration, TransitionType.FadeOut));
            StartCoroutine(LoadNextScene(transitionDuration));
        }

        private IEnumerator StartTransition(GameObject transitionObject, float duration, TransitionType transitionType)
        {
            Image transitionImage = transitionObject.GetComponent<Image>();
            Color startColor = transitionImage.color;
            Color endColor;

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
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(0);
        }
        private enum TransitionType
        {
            FadeIn,
            FadeOut
        }
    }
}
