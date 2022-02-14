using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class InputControllerByInputSystem : MonoBehaviour
{

    public Vector3 movemementXZ { get; private set; }
    public float rotationMagnitude { get; private set; }
    public bool isWalking { get; private set; }
    public bool isWalkingForward { get; private set; }
    public bool isRunning { get; private set; }

    //Defining Delegate
    public delegate void OnWeaponChange();
    public OnWeaponChange weaponChanged;

    // Start is called before the first frame update
    void Awake()
    {

    }

    public  void HandleRunning(InputAction.CallbackContext ctx)
    {
        isRunning = ctx.ReadValueAsButton();
    }

    public void HandleMovement(InputAction.CallbackContext ctx)
    {
        Vector2 move = ctx.ReadValue<Vector2>();
        movemementXZ = new Vector3(move.x, 0, move.y);
    }

    public void HandleWeaponChange(InputAction.CallbackContext ctx)
    {
        weaponChanged();
    }


    // Update is called once per frame
    void Update()
    {

        rotationMagnitude = movemementXZ.x;

        isWalking = movemementXZ.magnitude > Mathf.Epsilon;
        isWalkingForward = movemementXZ.z > Mathf.Epsilon;

    }

}
