using UnityEngine;
using UnityEngine.InputSystem;

namespace GoodPractices
{
    public class PlayerMove : MonoBehaviour                 // PascalCase for Classes and NameSpaces
    {
        private const float MAX_SPEED = 10f;                // SCREAMING CASE FOR CONSTANT

        private Vector3 _moveInput;                         // _underscoreCamelCase for private (or protected) fields (No confusion with parameters)

        [SerializeField] private float moveSpeed = 0.5f;           // _underscoreCamelCase for private (or protected) fields (No confusion with parameters)

        public bool IsMoving => _moveInput.magnitude > 0f;  // PascalCase for Public Properties
        
        // Update is called once per frame
        void Update()
        {
            // camelCase for local variables (same as parameters)
            Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y) * (moveSpeed * Time.deltaTime);
            transform.Translate(moveDirection);
        }

        
        public void OnMove(InputValue value)        // PascalCase and as expressive as possible for methods (public or private)
        {
            _moveInput = value.Get<Vector2>();
        }
    }
}
