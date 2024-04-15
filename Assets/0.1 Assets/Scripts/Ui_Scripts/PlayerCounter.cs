using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItsaMeKen
{
    public class PlayerCounter : MonoBehaviour
    {
        private static int playerCount = 0;
        private static PlayerCounter instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
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
          // Debug.Log("PlayerCount" + playerCount);
        }
    }
}
