using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{


    public class HitDetector : MonoBehaviour
    {
        public float forceThreshold = 10f;
        public float resetTime = 2f;
        public ConfigurableJoint[] joints;
        public MonoBehaviour[] scriptsToDisable;
        public float scriptDisableDelay = 1f;

        private bool isZeroSpringActive = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.relativeVelocity.magnitude > forceThreshold && !isZeroSpringActive)
            {
                isZeroSpringActive = true;
                SetJointsZeroSpring();
                StartCoroutine(ResetJointsAfterDelay());
                StartCoroutine(DisableScriptsAfterDelay());
            }
        }

        private void SetJointsZeroSpring()
        {
            foreach (ConfigurableJoint joint in joints)
            {
                JointDrive yzDrive = joint.angularYZDrive;
                yzDrive.positionSpring = 0f;
                joint.angularYZDrive = yzDrive;
            }
        }

        private IEnumerator ResetJointsAfterDelay()
        {
            yield return new WaitForSeconds(resetTime);
            ResetJointsToDefaultSpring();
        }

        private void ResetJointsToDefaultSpring()
        {
            foreach (ConfigurableJoint joint in joints)
            {

                JointDrive yzDrive = joint.angularYZDrive;
                yzDrive.positionSpring = 600f;
                joint.angularYZDrive = yzDrive;
            }


            isZeroSpringActive = false;
        }

        private IEnumerator DisableScriptsAfterDelay()
        {
            yield return new WaitForSeconds(scriptDisableDelay);

            foreach (MonoBehaviour script in scriptsToDisable)
            {
                script.enabled = false;
            }
        }
    }
}