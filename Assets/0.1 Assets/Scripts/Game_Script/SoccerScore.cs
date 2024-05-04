using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ItsaMeKen
{
    public class SoccerScore : MonoBehaviour
    {
        [Header("Score")]
        public GameObject scoreObjectText;
        public Text scoreText;
        private int score = 0;
        private int loseScore = 3;

        [Header("UI")]
        public GameObject lose;

        [Header("ball instantiate")]

        public GameObject ball;
        public Transform ballSpawnPoint;

        [Header("Sounds")]

        [SerializeField] private AudioClip[] winSoundClips;

        [Header("Transition")]
        public GameObject transitionFadeIn;
        public GameObject transitionFadeOut;
        public float transitionDuration = 1.5f;



        void Start()
        {


            scoreObjectText.SetActive(true);

            transitionFadeIn.SetActive(true);


            StartCoroutine(StartTransition(transitionFadeIn, transitionDuration, TransitionType.FadeIn));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ball"))
            {
                Destroy(other.transform.parent.gameObject);
                score++;
                SoundFXManager.instance.PlayRandomSoundFXClip(winSoundClips, transform, 0.7f);
                UpdateScoreText();
                SpawnBall();
            }
        }

        private void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: - " + score.ToString();
            }
        }

        private void SpawnBall()
        {
            Instantiate(ball, ballSpawnPoint.position, ballSpawnPoint.rotation);
        }

        void Update()
        {
            if(score == loseScore)
            {
                lose.SetActive(true);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        private enum TransitionType
        {
            FadeIn,
            FadeOut
        }
    }

}
    
