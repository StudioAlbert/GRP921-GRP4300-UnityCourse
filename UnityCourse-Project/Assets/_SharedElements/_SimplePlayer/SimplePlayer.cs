using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayer : MonoBehaviour 
{
    private Vector3 _moveInput;

    [SerializeField] private float moveSpeed = 0.5f; 
    [SerializeField] private float rotateSpeed = 60f; 

    // Update is called once per frame
    void FixedUpdate()
    {
        // camelCase for local variables (same as parameters)
        Vector3 moveDirection = new Vector3(0, 0, _moveInput.y) * (moveSpeed * Time.fixedDeltaTime);
        transform.Translate(moveDirection);
        
        float rotateQty = _moveInput.x * rotateSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up, rotateQty);
    }
    
    public void OnMove(InputValue value) 
    {
        _moveInput = value.Get<Vector2>();
    }
}
