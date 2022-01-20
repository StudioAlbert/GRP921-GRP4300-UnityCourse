using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpotter : MonoBehaviour
{

    private Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        if(camera == null)
        {
            camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Define a ray
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        // Draw it in the editor
        Debug.DrawRay(ray.origin, ray.direction * 25.0f, Color.green);

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
}
