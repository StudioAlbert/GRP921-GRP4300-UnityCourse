using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField]
    private float turningOffset;
    [SerializeField]
    private float angVelocityMax;

    [SerializeField]
    CinemachineCameraOffset camOffest;

    private Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float offsetAngleRatio = Mathf.InverseLerp(-1 * angVelocityMax, angVelocityMax, rb.angularVelocity.y);
        float effectiveTurningOffset = Mathf.Lerp(-1 * turningOffset, turningOffset, offsetAngleRatio);

        //Debug.Log("Angular vel : " + rb.angularVelocity.y + "Ratio : " + offsetAngleRatio + " Offset : " + effectiveTurningOffset);

        camOffest.m_Offset.x = effectiveTurningOffset;

    }
}
