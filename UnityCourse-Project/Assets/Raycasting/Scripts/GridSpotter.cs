using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpotter : MonoBehaviour
{

    private Camera camera;

    [SerializeField]
    GameObject gridCursor;

    private float gridSpacing = 1;
    private float gridSize = 10;

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
            if (hit.collider.CompareTag("Grid"))
            {
                gridCursor.SetActive(true);

                /*                float newX = Mathf.Round(hit.point.x / gridSpacing) * gridSpacing;
                                if(newX > 4 && newX < 5)
                                {
                                    newX -= 0.5f * gridSpacing;
                                }
                                if (newX < -4 && newX > -5)
                                {
                                    newX += 0.5f * gridSpacing;
                                }

                                float newZ = Mathf.Round(hit.point.z / gridSpacing) * gridSpacing;
                                if (newZ > 4 && newZ < 5)
                                {
                                    newZ -= 0.5f * gridSpacing;
                                }
                                if (newZ < -4 && newZ > -5)
                                {
                                    newZ += 0.5f * gridSpacing;
                                }

                                Vector3 newPosition = new Vector3(newX, hit.point.y, newZ);*/


                Vector3 newPosition = hit.point;
                Debug.Log("True coordinates : " + hit.point + " : Rounded coordinates : " + newPosition);

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
