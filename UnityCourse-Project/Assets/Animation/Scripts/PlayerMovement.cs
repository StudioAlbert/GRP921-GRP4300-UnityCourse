using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private InputControllerByInputSystem inputController;

    [SerializeField]
    private PlayerAnimation animation;

    [SerializeField]
    private float rotationSpeed = 1.0f;

    [SerializeField]
    private bool RotateOrLookAt = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Inputs : " + inputController.movemementXZ + ":" + inputController.isWalking + ":" + inputController.isRunning);

        if (RotateOrLookAt)
        {
             // version 1
           Vector3 positionToLookAt = transform.position + inputController.movemementXZ;
            transform.LookAt(positionToLookAt);
            animation.DoWalking(inputController.isWalking);

        }
        else
        {
            // Version 2 ----------------------------------------------------------------------------------------------------
            if (inputController.isWalkingForward)
            {
                transform.Rotate(Vector3.up, Time.deltaTime * inputController.rotationMagnitude * rotationSpeed);
            }
            animation.DoWalking(inputController.isWalkingForward);

        }

        // Running is the same not depending in versions
        animation.DoRunning(inputController.isRunning);

    }
}
