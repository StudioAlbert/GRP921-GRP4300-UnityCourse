using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    private int PV = 50;

    [SerializeField]
    Sword myOwnSword;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("PV : " + PV);
        if(PV <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Sword sw = collision.collider.gameObject.GetComponent<Sword>();

        if(sw != null)
        {
            if(sw != myOwnSword)
            {
                PV -= sw.GetDamages();
            }
        }
    }

}
