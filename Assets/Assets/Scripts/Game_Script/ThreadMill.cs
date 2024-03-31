using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class ThreadMill : MonoBehaviour
    {
        public Vector3 forceDirection = Vector3.forward;
        public float forceMagnitude = 10f;

        void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<Rigidbody>() != null)
            {
                ApplyConstantForce(other.GetComponent<Rigidbody>());
            }
        }

        void ApplyConstantForce(Rigidbody rb)
        {

            Vector3 forceVector = forceDirection.normalized * forceMagnitude;


            rb.AddForce(forceVector, ForceMode.Force);
        }
    }
}