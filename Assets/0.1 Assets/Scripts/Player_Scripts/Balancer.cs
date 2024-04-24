using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class Balancer : MonoBehaviour
    {
        public Transform Body;
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            transform.position = Body.position;
            rb.rotation = Quaternion.Euler(0f, rb.rotation.eulerAngles.y, 0f);
        }
    }
}
