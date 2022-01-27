using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMove : MonoBehaviour
{
    [SerializeField]
    private float turnForce;
    [SerializeField]
    private float accelerateForce;
    [SerializeField]
    private bool doMove;
    [SerializeField]
    private float brakeForce;

    [SerializeField]
    private float speedMax;

    private float turnInput;
    private float accelerateInput;
    private float brakeInput;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude < speedMax)
        {
            //transform.Rotate(Vector3.up, turnInput * turnForce * Time.deltaTime);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (rb.velocity.magnitude < speedMax)
        {
            doMove = true;

            float moveSum = accelerateInput * accelerateForce - brakeInput * brakeForce;
            rb.AddForce(moveSum * transform.forward);

            if(rb.velocity.magnitude > 0)
            {
                transform.Rotate(Vector3.up, turnInput * turnForce * Time.fixedDeltaTime);
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
