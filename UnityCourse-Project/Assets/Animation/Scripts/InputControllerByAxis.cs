using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InputControllerByAxis : MonoBehaviour
{
    
    public Vector3 movemementXZ { get; private set; }
    public float rotationMagnitude { get; private set; }
    public bool isWalking { get; private set; }
    public bool isWalkingForward { get; private set; }
    public bool isRunning { get; private set; }
    
    //Defining Delegate
    public delegate void OnButtonClickDelegate();
    public OnButtonClickDelegate buttonClickDelegate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movemementXZ = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rotationMagnitude = Input.GetAxis("Horizontal");

        isWalking = movemementXZ.magnitude > Mathf.Epsilon;
        isWalkingForward = Mathf.Abs(movemementXZ.z) > Mathf.Epsilon;

        isRunning = Input.GetButton("Running");

        //Debug.Log("Inputs : " + movement + ":" + isWalking + ":" + isRunning);

        if (Input.GetButtonUp("WeaponChange"))
        {
            //Calling Delegates
            buttonClickDelegate();
        }

    }

}
