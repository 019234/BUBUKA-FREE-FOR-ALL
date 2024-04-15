using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItsaMeKen
{
    public class JoinButton : MonoBehaviour
    {
        [SerializeField] private string join1 = "JP1";
        [SerializeField] private string join2 = "JP2";
        [SerializeField] private string join3 = "JP3";
        [SerializeField] private string join4 = "JP4";

        private bool hasDoneAction1 = false;
        private bool hasDoneAction2 = false;
        private bool hasDoneAction3 = false;
        private bool hasDoneAction4 = false;

        private PlayerCounter playerCounter;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            StartCoroutine(Join());
        }

        private IEnumerator Join()
        {
            yield return new WaitForSeconds(0.5f);
            hasDoneAction1 = false;
            hasDoneAction2 = false;
            hasDoneAction3 = false;
            hasDoneAction4 = false;
        }

        private void Start()
        {
            playerCounter = FindObjectOfType<PlayerCounter>();
        }

        private void Update()
        {
            //p1
            if (!hasDoneAction1 && Input.GetButtonDown(join1))
            {
                if (playerCounter != null)
                {
                    playerCounter.IncrementPlayerCount();
                    Debug.Log("P1 Joined");
                }
                hasDoneAction1 = true;
            }

            //p2
            if (!hasDoneAction2 && Input.GetButtonDown(join2))
            {
                if (playerCounter != null)
                {
                    playerCounter.IncrementPlayerCount();
                }
                hasDoneAction2 = true;
            }

            //p3
            if (!hasDoneAction3 && Input.GetButtonDown(join3))
            {
                if (playerCounter != null)
                {
                    playerCounter.IncrementPlayerCount();
                }
                hasDoneAction3 = true;
            }

            //p4
            if (!hasDoneAction4 && Input.GetButtonDown(join4))
            {
                if (playerCounter != null)
                {
                    playerCounter.IncrementPlayerCount();
                }
                hasDoneAction4 = true;
            }
        }
    }
}
