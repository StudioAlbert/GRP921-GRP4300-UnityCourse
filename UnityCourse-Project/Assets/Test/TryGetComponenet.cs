using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryGetComponenet : MonoBehaviour
{
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.TryGetComponent(out rb))
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
