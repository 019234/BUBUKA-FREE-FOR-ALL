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

        private void OnCollisionEnter(Collision collision)
        {
            if (!_isPermanentZeroSpring && collision.relativeVelocity.magnitude >= forceThreshold)
            {
                // Print the force
                Debug.Log("Collision Force: " + collision.relativeVelocity.magnitude);

                // Set joints' spring to zero
                SetPositionSpringToPress(_zeroSpring);

                // Disable target scripts
                foreach (Behaviour script in targetScripts)
                {
                    if (script != null)
                    {
                        script.enabled = false;
                    }
                }

                // Increment zero spring count
                _zeroSpringCount++;

                // Check if it reached the maximum zero springs
                if (_zeroSpringCount >= _maxZeroSpringCount)
                {
                    // Set joints' spring permanently to zero
                    SetPositionSpringToPress(_zeroSpring);

                    // Mark as permanently set to zero
                    _isPermanentZeroSpring = true;
                }
                else
                {
                    // Reset joints' spring to default after 10 seconds
                    StartCoroutine(ResetToDefaultSpringAfterDelay(10f));
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

            // Set joints' spring back to default
            SetPositionSpringToPress(_defaultSpring);

            // Enable target scripts
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