using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastSpotter : MonoBehaviour
{

    float rotationInput;

    [SerializeField]
    float rotationAmplitude = 100;

    [SerializeField]
    private bool raycastMultiple;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up, Time.deltaTime * rotationInput * rotationAmplitude);
        
        // Define a ray
        Ray ray = new Ray(transform.position, transform.forward);
        // Draw it in the editor
        Debug.DrawRay(ray.origin, ray.direction * 25.0f, Color.yellow);

        if (raycastMultiple)
        {
            RaycastAll(ray);
        }
        else
        {
             RaycastOne(ray);
        }
    }

    private static void RaycastOne(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            RaycastSpottable spotted = hit.collider.gameObject.GetComponent<RaycastSpottable>();
            if (spotted != null)
            {
                spotted.SpotObject();
            }
            else
            {
                Debug.Log("This object is not spottable");
            }

        }

    }
    private static void RaycastAll(Ray ray)
    {
        List<RaycastHit> hits;
        hits = Physics.RaycastAll(ray).ToList();

        foreach(var hit in hits)
        {
        
            RaycastSpottable spotted = hit.collider.gameObject.GetComponent<RaycastSpottable>();
            if (spotted != null)
            {
                spotted.SpotObject();
            }
            else
            {
                Debug.Log("This object is not spottable");
            }

        }

    }

    public void HandleRotate(InputAction.CallbackContext ctx)
    {
        rotationInput = ctx.ReadValue<float>();
    }


}
