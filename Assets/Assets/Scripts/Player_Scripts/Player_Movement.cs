using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItsaMeKen
{

    public class Player_Movement : MonoBehaviour
    {
        [Header("Animation")]
        public Animator _anim;

        [Header("Player Variable")]
        public Rigidbody _mover;
        public float _speed = 5f;
        public float _airSpeed = 2.5f;
        public float _jumpPower = 10f;
        public float _forwardJumpForce = 10f;
        public float _groundCheckDistance = 0.2f;
        public LayerMask _groundLayer;

        [Header("Fist")]
        public Rigidbody fist_Right;
        public Rigidbody fist_Left;
        public float _punchPower = 5f;

        [Header("Dive / HeadBut")]
        public Rigidbody _head;
        public float _headbutForce = 0f;


        [Header("Idle Animation")]
        public float idleThreshold = 0.1f;
        public float idleTimeThreshold = 3f;
        private float idleTimer = 0f;
        public float moveThreshold = 0.1f;

        [Header("Input Names")]
        [SerializeField] private string _inputNameHorizontal;
        [SerializeField] private string _inputNameVertical;
        [SerializeField] private string _inputNameJump;
        [SerializeField] private string _inputNameGrabRight;
        [SerializeField] private string _inputNameGrabLeft;
        [SerializeField] private string _inputNameDive;


        private bool isMoving = false;
        private bool isJumping = false;
        private bool isDiving = false;
        private bool IsIdleTooLong = false;

        void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis(_inputNameHorizontal);
            float verticalInput = Input.GetAxis(_inputNameVertical);

            if (IsGrounded())
            {
                Vector3 movementDirection = new Vector3(-verticalInput, 0, horizontalInput).normalized;

                if (movementDirection.magnitude > moveThreshold)
                {
                    isMoving = true;
                    _mover.AddForce(movementDirection * _speed);
                }
                else
                {
                    isMoving = false;
                }

                ////////////////////////////////////////////////////////////////////// Walking Animation
                if (isMoving)
                {
                    _anim.SetBool("IsWalking", true);
                }
                else
                {
                    _anim.SetBool("IsWalking", false);
                }
            }
            else /////////////////////////////////////////////////////////////////////  Air movement
            {
                Vector3 airMovement = new Vector3(-verticalInput, 0, horizontalInput).normalized * _airSpeed;
                _mover.AddForce(airMovement);
            }

            if (IsGrounded() && Input.GetButtonDown(_inputNameJump))
            {
                isJumping = true;
                Jump();
            }

            /////////////////////////////////////////////////////////////////////  Idle Animation
            if (isJumping = true && !isMoving)
            {
                idleTimer += Time.deltaTime;

                if (idleTimer >= idleTimeThreshold)
                {
                    _anim.SetBool("IdleTooLong", true);
                    IsIdleTooLong = true;
                }
            }
            else
            {
                idleTimer = 0f;
                _anim.SetBool("IdleTooLong", false);
                IsIdleTooLong = false;
            }

            ///////////////////////////////////////////////////////////////////// FUCK  YOU ANIMATION
            if (Input.GetButtonDown(_inputNameGrabRight))
            {
                Vector3 forwardForce = -transform.right * _punchPower;
                fist_Right.AddForce(forwardForce, ForceMode.Impulse);

                _anim.SetBool("Right_FuckYou", true);
            }
            else if (Input.GetButtonUp(_inputNameGrabRight))
            {
                Vector3 forwardForce = -transform.right * _punchPower;

                fist_Left.AddForce(forwardForce, ForceMode.Impulse);

                _anim.SetBool("Right_FuckYou", false);
            }

            if (Input.GetButtonDown(_inputNameGrabLeft))
            {
                Vector3 forwardForce = -transform.right * _punchPower;
                _anim.SetBool("Left_FuckYou", true);
            }
            else if (Input.GetButtonUp(_inputNameGrabLeft))
            {
                _anim.SetBool("Left_FuckYou", false);
            }

            /////////////////////////////////////////////////////////////////////  DIVE/HEADBUTT

            if (Input.GetButtonDown(_inputNameDive))
            {

                Vector3 forwardForce = -transform.right * _headbutForce;
                _head.AddForce(forwardForce, ForceMode.Impulse);

            }
        }

        void Jump()
        {
            Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(2 * _jumpPower * Mathf.Abs(Physics.gravity.y));

            _mover.velocity = new Vector3(_mover.velocity.x, 0f, _mover.velocity.z);
            _mover.velocity += jumpVelocity;

            Vector3 forwardForce = -transform.right * _forwardJumpForce;
            _mover.AddForce(forwardForce, ForceMode.Impulse);
        }

        bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance, _groundLayer);
        }
    }
}