using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    int hashBounce;

    // Start is called before the first frame update
    void Start()
    {
        hashBounce = Animator.StringToHash("IsBounced");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleBounce(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            animator.SetBool(hashBounce, true);
        }

        if (ctx.canceled)
        {
            animator.SetBool(hashBounce, false);
        }

    }
}
