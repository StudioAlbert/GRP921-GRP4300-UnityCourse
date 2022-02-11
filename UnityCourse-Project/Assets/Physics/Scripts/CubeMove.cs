using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private Rigidbody rb;
    private float inputForce;

    [SerializeField]
    private float forceMagnitude;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * forceMagnitude * inputForce);
    }

    private void Update()
    {
        inputForce = Input.GetAxis("Vertical");
    }
}
