using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + "colliding(enter) with : " + collision.gameObject.name);
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(name + "colliding(exit) with : " + collision.gameObject.name);
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(name + "colliding(stay) with : " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + "triggering(enter) with : " + other.gameObject.name);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(name + "triggering(exit) with : " + other.gameObject.name);
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(name + "triggering(stay) with : " + other.gameObject.name);
    }

}
