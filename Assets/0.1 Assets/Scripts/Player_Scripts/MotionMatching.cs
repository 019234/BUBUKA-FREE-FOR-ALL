using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class MotionMatch : MonoBehaviour
    {

        public Transform CopyLimbs;
        ConfigurableJoint cj;
        Quaternion startRotation;



        private void Start()
        {

            cj = GetComponent<ConfigurableJoint>();
            startRotation = transform.localRotation;

        }
        private void Update()
        {

            cj.SetTargetRotationLocal(CopyLimbs.localRotation, startRotation);


        }


    }
}