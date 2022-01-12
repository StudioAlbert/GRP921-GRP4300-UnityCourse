using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUpdates : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Object awaking");
    }

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Object starting");
    }

    private void FixedUpdate()
    {
        Debug.Log("Object Fixed updating : " + Time.fixedDeltaTime);
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("Object updating : " + Time.deltaTime);
    }

    private void LateUpdate()
    {
        Debug.Log("Object late updating : " + Time.deltaTime);
    }
}
