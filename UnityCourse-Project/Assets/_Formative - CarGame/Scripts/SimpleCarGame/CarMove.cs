using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SimpleCarGame
{
    public class CarMove : MonoBehaviour
    {
        [SerializeField] private float turnForce;
        [SerializeField] private float accelerateForce;
        [SerializeField] private bool doMove;
        [SerializeField] private float brakeForce;
        [SerializeField] private float gravityForce = 25f;

        [SerializeField] private float speedMax;

        private float turnInput;
        private float accelerateInput;
        private float brakeInput;

        private Rigidbody rb;

        private bool grounded;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

            if (GameManager.GameOver)
                return;

            Ray groundedRay = new Ray(transform.position, transform.up * -1f);
            Debug.DrawRay(groundedRay.origin, groundedRay.direction * 2f, Color.blue);

            if (Physics.Raycast(groundedRay, 2f))
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }

            if (rb.velocity.magnitude < speedMax)
            {
                doMove = true;

                float moveSum = accelerateInput * accelerateForce - brakeInput * brakeForce;
                rb.AddForce(moveSum * transform.forward);

                if (rb.velocity.magnitude > 0)
                {
                    transform.Rotate(Vector3.up, turnInput * turnForce * Time.fixedDeltaTime);
                }

                if (!grounded)
                {
                    rb.AddForce(Vector3.down * gravityForce);
                }

            }
            else
            {
                doMove = false;
            }

            Debug.Log("Do move ? : " + doMove);

        }

        public void InputAccelerate(InputAction.CallbackContext ctx)
        {
            accelerateInput = ctx.ReadValue<float>();
        }

        public void InputBrake(InputAction.CallbackContext ctx)
        {
            brakeInput = ctx.ReadValue<float>();
        }

        public void InputTurn(InputAction.CallbackContext ctx)
        {
            turnInput = ctx.ReadValue<float>();
        }
    }

}