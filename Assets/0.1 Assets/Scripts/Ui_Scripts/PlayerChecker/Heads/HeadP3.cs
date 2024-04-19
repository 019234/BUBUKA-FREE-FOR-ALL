using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    public class HeadP3 : MonoBehaviour
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

        private bool isAlive = true;
        private bool isAsleep = false;

        private string newTag = "Dead";
        public GameObject objectToChangeTag;

        private void Awake()
        {
            isAlive = true;
        }

        public void Update()
        {
            if (_isPermanentZeroSpring)
            {
                isAlive = false;

                if (objectToChangeTag != null)
                {
                    objectToChangeTag.tag = newTag;
                }
            }

            if (_unconscious)
            {
                isAsleep = true;
            }
            else if (!_unconscious)
            {
                isAsleep = false;
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

            _unconscious = false;

            SetPositionSpringToPress(_defaultSpring);

            foreach (Behaviour script in targetScripts)
            {
                if (script != null)
                {
                    script.enabled = true;
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!_isPermanentZeroSpring && collision.relativeVelocity.magnitude >= forceThreshold)
            {
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
                    _isPermanentZeroSpring = true;
                    SetPositionSpringToPress(_zeroSpring);

                    foreach (Behaviour script in targetScripts)
                    {
                        if (script != null)
                        {
                            script.enabled = false;
                        }
                    }
                }
                else
                {
                    StartCoroutine(ResetToDefaultSpringAfterDelay(10f));
                    isAlive = true;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("killZone"))
            {
                isAlive = false;
                SetPositionSpringToPress(_zeroSpring);

                foreach (Behaviour script in targetScripts)
                {
                    if (script != null)
                    {
                        script.enabled = false;
                    }
                }
            }
        }

        public bool IsAlive()
        {
            return isAlive;
        }

        public bool IsSleeping()
        {
            return isAsleep;
        }
    }
}
