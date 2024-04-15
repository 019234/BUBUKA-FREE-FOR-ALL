using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class PlayersNeeded : MonoBehaviour
    {

        private int playersNeeded = 2;
        private PlayerCounter playerCounter;
        public MonoBehaviour[] _scriptsToDisable;

 
        void Start()
        {
            playerCounter = FindObjectOfType<PlayerCounter>();
        }

 
        void Update()
        {
            if (playersNeeded == playerCounter.GetPlayerCount()) //if the PlayerNeeded equals to playerCount this will happened
            {
                DisableScripts(false);
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
