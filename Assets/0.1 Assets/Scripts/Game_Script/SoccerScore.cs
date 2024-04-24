using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItsaMeKen
{
    public class SoccerScore : MonoBehaviour
    {
        [Header("Score")]
        public GameObject scoreObjectText;
        public Text scoreText;
        private int score = 0;

        [Header("ball instantiate")]

        public GameObject ball;
        public Transform ballSpawnPoint;

        void Start()
        {
            scoreObjectText.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ball"))
            {
                Destroy(other.gameObject);
                score++;
                UpdateScoreText();
                SpawnBall();
            }
        }

        private void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score.ToString();
            }
        }

        private void SpawnBall()
        {
            Instantiate(ball, ballSpawnPoint.position, ballSpawnPoint.rotation);
        }
    }
}
