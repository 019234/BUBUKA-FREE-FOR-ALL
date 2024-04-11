using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItsaMeKen
{
    public class SceneTransitionTrigger : MonoBehaviour
    {
        private int playersInside = 0;
        private PlayerCounter playerCounter;

        private void Start()
        {
            playerCounter = FindObjectOfType<PlayerCounter>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playersInside++;
                Debug.Log("playersInside: " + playersInside);

                if (playersInside == playerCounter.GetPlayerCount())
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    }
}