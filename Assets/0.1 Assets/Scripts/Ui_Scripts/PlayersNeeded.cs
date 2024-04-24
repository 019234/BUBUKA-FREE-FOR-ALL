using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class PlayersNeeded : MonoBehaviour
    {

        private int playersNeeded = 2;
        private PlayerCounter playerCounter;
        [SerializeField] private GameObject pause;
        [SerializeField] private GameObject uiManager;
        public MonoBehaviour[] _scriptsToDisable;


 
        void Start()
        {
            playerCounter = FindObjectOfType<PlayerCounter>();
        }

 
        void Update()
        {
            if (playersNeeded == playerCounter.GetPlayerCount()) 
            {
                DisableScripts(false);
                pause.SetActive(true);
                uiManager.SetActive(false);

            }
            else
            {
                DisableScripts(true);
            }
        }

        void DisableScripts(bool disable)
        {
            foreach (MonoBehaviour script in _scriptsToDisable)
            {
                script.enabled = !disable;

            }
        }
    }
}
