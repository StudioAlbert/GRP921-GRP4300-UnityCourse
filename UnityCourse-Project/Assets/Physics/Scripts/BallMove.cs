using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMove : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;
  
    private Rigidbody rb;

    [SerializeField]
    private float jumpAmplification = 5;
    private bool jumpOrder;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("Rigidbody ok");
        }
        else
        {
            Debug.LogWarning("No rigidbody");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * forceMagnitude);

        if (jumpOrder)
        {
            rb.AddForce(Vector3.up * jumpAmplification, ForceMode.Impulse);
            jumpOrder = false;
        }
    }

    private void OnForward(InputValue value)
    {
        forceMagnitude = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        Debug.Log("Jump !");
        jumpOrder = true;
    }
}
