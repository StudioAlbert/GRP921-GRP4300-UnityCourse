using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealerInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo))
            {
                ITakeDamage damageableTarget = hitInfo.collider.GetComponent<ITakeDamage>();
                if(damageableTarget != null)
                {
                    damageableTarget.TakeDamage(1);
                }
            }

        }
   



    }
}
