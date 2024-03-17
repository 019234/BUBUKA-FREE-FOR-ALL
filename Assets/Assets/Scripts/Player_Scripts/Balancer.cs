using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class Balancer : MonoBehaviour
    {
        public Transform Body;
 

        void FixedUpdate()
        {
 
            transform.position = Body.position;

  
        }
    }
}