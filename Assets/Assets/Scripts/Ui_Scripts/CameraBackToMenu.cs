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

        [SerializeField] private GameObject objectToRenable;
        [SerializeField] private GameObject objectToRenable1;

        void Update()
        {
             
            if (Input.GetKeyDown(keyToPress))
            {

                objectBody.transform.position = targetBody.position;
                objectLook.transform.position = targetLook.position;

                objectToRenable.SetActive(true);
                objectToRenable1.SetActive(true);
            }
        }
    }
}