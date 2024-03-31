using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class BallController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float rotateSpeed = 100f;

        void Update()
        {

            float horizontalInput = Input.GetAxis("HA1");
            float verticalInput = Input.GetAxis("VA1");


            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);


            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }
        }
    }
}