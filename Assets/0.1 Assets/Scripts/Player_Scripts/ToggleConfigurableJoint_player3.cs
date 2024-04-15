using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{
    [RequireComponent(typeof(ConfigurableJoint))]
    public class ToggleConfigureJointPlayer3 : MonoBehaviour
    {
        public ConfigurableJoint[] _targetJoints;
        public MonoBehaviour[] _scriptsToDisable;
        public float _defaultSpring = 500f;
        public float _zeroSpring = 50f;
        private int _zeroSpringCount = 0;

        private bool isDPadPressed = false;


        [SerializeField] private string _inputNameDive;

        void Update()
        {
            if (!isDPadPressed && Input.GetAxisRaw(_inputNameDive) > 0.5f)
            {
                SetPositionSpringToPress(_zeroSpring);
                DisableScripts(true);
                isDPadPressed = true;
            }

            if (isDPadPressed && Input.GetAxisRaw(_inputNameDive) <= 0.5f)
            {
                SetPositionSpringToPress(_defaultSpring);
                DisableScripts(false);
                isDPadPressed = false;
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

        void DisableScripts(bool disable)
        {
            foreach (MonoBehaviour script in _scriptsToDisable)
            {
                script.enabled = !disable;
            }
        }
    }
}

