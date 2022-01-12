using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{

    public Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(
            Input.GetAxis("Horizontal"),
            0, 
            Input.GetAxis("Vertical"));

        if (Input.GetAxis("Fire1") != 0)
        {

        }

    }
}
