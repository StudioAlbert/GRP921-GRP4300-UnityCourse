using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInput : MonoBehaviour
{

    private Vector3 _movement;
    public Vector3 Movement { 
        get { return _movement; } 
        private set { _movement = value; } 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            _movement.z = 1f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            _movement.z = -1f;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            _movement.z = 0f;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            _movement.x = -1f;  
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            _movement.x = 1f;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _movement.x = 0f;
        }

    }
}
