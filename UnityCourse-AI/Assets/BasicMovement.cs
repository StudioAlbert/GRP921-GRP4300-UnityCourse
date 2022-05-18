using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    
    [SerializeField] Transform followPoint;

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector3.Distance(transform.position, followPoint.position) > 0.0001f) ;
        //     transform.position = Vector3.Lerp(transform.position, followPoint.position, 0.01f);
        
        _rb.velocity = Vector3.forward * 5f;
        
    }
}
