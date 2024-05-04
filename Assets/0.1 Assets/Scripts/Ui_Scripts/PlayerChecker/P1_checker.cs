using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItsaMeKen
{
    public class P1_checker : MonoBehaviour
    {
        [SerializeField] private string _inputNameJump;
        private bool playerExists = false;

        private PlayerCounter playerCounter;

        private static P1_checker instance;

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

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            StartCoroutine(ReInitialized());
        }

        private IEnumerator ReInitialized()
        {
            yield return new WaitForSeconds(0.5f);
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
