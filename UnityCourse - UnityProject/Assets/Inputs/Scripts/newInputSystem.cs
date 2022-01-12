using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class newInputSystem : MonoBehaviour
{

    InputActions actions;

    private Vector3 _movement;
    public Vector3 Movement
    {
        get { return _movement; }
        private set { _movement = value; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        actions = new InputActions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        actions.Enable();
        actions.BasicMovement.UpDwon.performed += ctx => HandleMovementX(ctx);
        actions.BasicMovement.LeftRight.performed += ctx => HandleMovementZ(ctx);
    }
    private void OnDisable()
    {
        actions.Disable();
        actions.BasicMovement.UpDwon.performed -= ctx => HandleMovementX(ctx);
        actions.BasicMovement.LeftRight.performed -= ctx => HandleMovementZ(ctx);
    }
    private void HandleMovementX(InputAction.CallbackContext ctx)
    {
        _movement.x = ctx.ReadValue<float>();
    } 
    private void HandleMovementZ(InputAction.CallbackContext ctx)
    {
        _movement.z = ctx.ReadValue<float>();
    }

}
