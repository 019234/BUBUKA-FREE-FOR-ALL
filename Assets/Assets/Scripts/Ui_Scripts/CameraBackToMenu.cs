using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is responsible for going back to the menu, 

namespace ItsaMeKen
{
    public class CameraBackToMenu : MonoBehaviour
    {
        public KeyCode keyToPress;
        public GameObject objectBody;
        public Transform targetBody;
        public GameObject objectLook;
        public Transform targetLook;

        void Start()
        { 
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
             
            if (Input.GetKeyDown(keyToPress))
            {

                objectBody.transform.position = targetBody.position;
                objectLook.transform.position = targetLook.position;
            }
        }
    }
}