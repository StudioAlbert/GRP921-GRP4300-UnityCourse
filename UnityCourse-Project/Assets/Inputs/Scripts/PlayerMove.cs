using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    //[SerializeField]
    //PlayerInput inputs;
    //PlayerInputSystem inputs;
    //PlayerNewInputSystem inputs;

    [SerializeField]
    float moveSpeed = 0.1f;

    private Vector3 _movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_movement * Time.deltaTime * moveSpeed);
    }

    // This is used when Behavior is : Invoke Unity Events
    public void HandleMovement(InputAction.CallbackContext ctx)
    {
        _movement.x = ctx.ReadValue<Vector2>().x;
        _movement.z = ctx.ReadValue<Vector2>().y;
    }

    // This is used when Player Input Behavior is : Send Messages
    private void OnMove(InputValue value)
    {
        _movement.x = value.Get<Vector2>().x;
        _movement.z = value.Get<Vector2>().y;
    }

}
