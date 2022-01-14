using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletLauncher : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float fireAmplitude = 200f;

    private bool fireOrder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fireOrder)
        {
            GameObject bulletLaunched = Instantiate(bullet, firePoint);

            Rigidbody rb = bulletLaunched.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * fireAmplitude, ForceMode.Impulse);

            fireOrder = false;
        }

    }

    public void HandleFire()
    {
        fireOrder = true;
    }

}
