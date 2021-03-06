using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDamageDealer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Mob damageableTarget = hitInfo.collider.GetComponent<Mob>();
                if (damageableTarget != null)
                {
                    damageableTarget.TakeDamage(1);
                }
            }

        }

    }
}
