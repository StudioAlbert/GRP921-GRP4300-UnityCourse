using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class TankMove : MonoBehaviour
{
    [SerializeField]
    private float forceAmplification = 5;
    private float forceMagnitude;

    [SerializeField]
    private float torqueAmplitude = 5;
    private float turnMagnitude;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //;
        if (!(rb = GetComponent<Rigidbody>()))
        {
            Debug.LogError("Tank has no rigidbody.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * forceMagnitude * forceAmplification);
        rb.AddTorque(transform.up * turnMagnitude * torqueAmplitude);
    }

    public void HandleTurnInput(CallbackContext context)
    {
        turnMagnitude = context.ReadValue<float>();
    }
    public void HandleForwardInput(CallbackContext context)
    {
        forceMagnitude = context.ReadValue<float>();
    }

}
