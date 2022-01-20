using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfetRate : MonoBehaviour
{

    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("Delta time = " + Time.deltaTime);

        if(timer >= 1.0f)
        {
            Debug.Log("Happen event : " + DateTime.Now);
        }
    }
}
