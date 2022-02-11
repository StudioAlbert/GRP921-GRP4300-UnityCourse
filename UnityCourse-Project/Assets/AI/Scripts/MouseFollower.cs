using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0))
        {
            // Define a ray
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            // Draw it in the editor
            Debug.DrawRay(ray.origin, ray.direction * 1000.0f, Color.green);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("Ground"))
                {
                    transform.position = hit.point;
                } 
            }
        }

    }
}
