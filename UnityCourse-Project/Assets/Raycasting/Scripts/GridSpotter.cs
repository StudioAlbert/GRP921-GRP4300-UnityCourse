using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpotter : MonoBehaviour
{
    private Camera camera;
    [SerializeField] GameObject gridCursor;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
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
            if (hit.collider.CompareTag("Grid"))
            {
                gridCursor.SetActive(true);
                Vector3 newPosition = hit.point;
                gridCursor.transform.position = newPosition;
            }
            else
            {
               gridCursor.SetActive(false);
            }
        }else
        {
            gridCursor.SetActive(false);
        }
    }
}
