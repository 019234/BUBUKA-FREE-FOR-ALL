using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace itsaMeKen
{
    public class ForceDetector : MonoBehaviour
    {
        public float forceThreshold = 10f;
        public ConfigurableJoint[] _targetJoints;
        public Behaviour[] targetScripts;
        public float _zeroSpring = 0f;
        public float _defaultSpring = 500f;
        public int _maxZeroSpringCount = 3;

        private int _zeroSpringCount = 0;
        private bool _isPermanentZeroSpring = false;
        private bool _isDead = false;
        private bool _unconscious = false;
        private bool _debug = false;



        private void OnCollisionEnter(Collision collision)
        {
            if (!_isPermanentZeroSpring && collision.relativeVelocity.magnitude >= forceThreshold)
            {
                
                Debug.Log("Collision Force: " + collision.relativeVelocity.magnitude);

                _unconscious = true;

                SetPositionSpringToPress(_zeroSpring);

              
                foreach (Behaviour script in targetScripts)
                {
                    if (script != null)
                    {
                        script.enabled = false;
                    }
                }

                _zeroSpringCount++;

                if (_zeroSpringCount >= _maxZeroSpringCount)
                {

                    SetPositionSpringToPress(_zeroSpring);

                    _isPermanentZeroSpring = true;
                }
                else
                {
                    
                    StartCoroutine(ResetToDefaultSpringAfterDelay(10f));

                }
            }
        }

        public void Update()
        {
            if (_isPermanentZeroSpring)
            {
                if (!_isDead)
                {
                    _isDead = true;
                    Debug.Log("Object is permanently dead.");
                }
            }

            if (_unconscious)
            {
                if (!_debug)
                {
                    _debug = true;
                    Debug.Log("this nigga asleep");
                }
                
            }


        }

        void SetPositionSpringToPress(float spring)
        {
            foreach (ConfigurableJoint joint in _targetJoints)
            {
                JointDrive xDrive = joint.angularXDrive;
                xDrive.positionSpring = spring;
                joint.angularXDrive = xDrive;

                JointDrive yzDrive = joint.angularYZDrive;
                yzDrive.positionSpring = spring;
                joint.angularYZDrive = yzDrive;
            }
        }

        IEnumerator ResetToDefaultSpringAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);

            SetPositionSpringToPress(_defaultSpring);

            _unconscious = false;

            foreach (Behaviour script in targetScripts)
            {
                if (script != null)
                {
                    script.enabled = true;
                }
            }
        }
    }
}