
using System.Collections;
using UnityEngine;

namespace ItsaMeKen
{
    public class Grabbing : MonoBehaviour
    {
        private bool isGrabbing;
        private Rigidbody _grabbedObject;
        public bool _canGrab;
        public float _grabRange = 0.5f;
        public float _throwForce = 5f;
        public float _grabTimeLimit = 8f;
        private float _grabTimer;

        [SerializeField] private string _inputNameGrab;

        void Update()
        {
            if (_canGrab)
            {
                if (Input.GetButton(_inputNameGrab))
                {
                    if (!isGrabbing)
                    {
                        GrabObject();
                        _grabTimer = 0f;
                    }
                }
                else if (isGrabbing && Input.GetButtonUp(_inputNameGrab))
                {
                    ReleaseGrab();
                }


                if (isGrabbing)
                {
                    _grabTimer += Time.deltaTime;
                    if (_grabTimer >= _grabTimeLimit)
                    {
                        ReleaseGrab();
                    }
                }
            }
        }

        void GrabObject()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, _grabRange))
            {
                Rigidbody targetRigidbody = hit.collider.GetComponent<Rigidbody>();
                if (targetRigidbody != null && targetRigidbody.CompareTag("Grabbable") || targetRigidbody.CompareTag("Player"))
                {
                    isGrabbing = true;
                    _grabbedObject = targetRigidbody;

                    FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = _grabbedObject;
                    joint.connectedAnchor = transform.InverseTransformPoint(hit.point);
                }
            }
        }

        void ReleaseGrab()
        {
            if (isGrabbing)
            {
                isGrabbing = false;

                FixedJoint joint = GetComponent<FixedJoint>();
                if (joint != null)
                {
                    Destroy(joint);
                }

                if (_grabbedObject != null)
                {
                    _grabbedObject.AddForce(transform.forward * _throwForce, ForceMode.Impulse);
                    _grabbedObject = null;
                }
            }
        }
    }
}