using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class CharacterRotation : MonoBehaviour
    {
        public float rotationSpeed = 50f;

        [SerializeField] private string inputNameHorizontal;
        [SerializeField] private string inputNameVertical;


        void Update()
        {
            float horizontalInput = Input.GetAxis(inputNameHorizontal);
            float verticalInput = Input.GetAxis(inputNameVertical);




            Vector3 targetDirection = new Vector3(horizontalInput, 0f, verticalInput);
            if (targetDirection.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

        }
    }
}