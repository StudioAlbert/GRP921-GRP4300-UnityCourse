using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject newBullet = Instantiate(bullet, shootPoint);
            newBullet.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 15), ForceMode.Impulse);
        }
    }
}
