using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItsaMeKen
{
    public class PlayerCounter : MonoBehaviour
    {
        private int playerCount = 0;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            StartCoroutine(DeZero());
        }

        private IEnumerator DeZero()
        {
            yield return new WaitForSeconds(0.1f);
            playerCount = 0;
        }

        public void IncrementPlayerCount()
        {
            playerCount++;
            Debug.Log("Player count: " + playerCount);
        }

        public void DecrementPlayerCount()
        {
            playerCount--;
            Debug.Log("Player count: " + playerCount);
        }

        public int GetPlayerCount()
        {
            return playerCount;
        }

        void Update()
        {
            Debug.Log("PlayerCount" + playerCount);
        }
    }
}
