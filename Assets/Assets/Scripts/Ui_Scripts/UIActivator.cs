using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class UIActivator : MonoBehaviour
    {

        public KeyCode keyToPress;
        public GameObject objectToToggle;  
        private bool isActivated = false;   

        void Update()
        {
            if (Input.GetKeyDown(keyToPress))
            {
                isActivated = !isActivated;

                objectToToggle.SetActive(isActivated);
            }
        }
    }
}
