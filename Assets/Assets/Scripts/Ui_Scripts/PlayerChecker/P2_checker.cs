using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItsaMeKen
{
    public class P2_checker : MonoBehaviour
    {
        [SerializeField] private string _inputNameJump;
        private bool playerExists = false;

        private PlayerCounter playerCounter;

        public MonoBehaviour[] _scriptsToToggle;

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
            playerExists = false;
            playerCounter = FindObjectOfType<PlayerCounter>();
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
                ToggleScripts();

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

        void ToggleScripts()
        {
            foreach (MonoBehaviour script in _scriptsToToggle)
            {
                script.enabled = !script.enabled;
            }
        }
    }
}

