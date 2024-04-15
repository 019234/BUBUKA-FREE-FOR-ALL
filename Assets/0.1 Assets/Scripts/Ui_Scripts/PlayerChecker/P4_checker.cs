using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItsaMeKen
{
    public class P4_checker : MonoBehaviour
    {
        [SerializeField] private string _inputNameJump;
        private bool playerExists = false;

        private PlayerCounter playerCounter;


        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            StartCoroutine(ReInitialized());
        }

        private IEnumerator ReInitialized()
        {
            yield return new WaitForSeconds(0.5f);
            //playerExists = false;

        }

        void Start()
        {
            playerCounter = FindObjectOfType<PlayerCounter>();
        }

        private void Update()
        {
            if (!playerExists && Input.GetButtonDown(_inputNameJump))
            {
                playerExists = true;

                if (playerCounter != null)
                {
                    playerCounter.IncrementPlayerCount();
                }
            }

        }

        public bool DoesPlayerExist()
        {
            return playerExists;
        }
    }
}

