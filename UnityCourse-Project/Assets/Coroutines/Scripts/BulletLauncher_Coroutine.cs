using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class BulletLauncher_Coroutine : MonoBehaviour
{
    [SerializeField]
    GameObject bulletModel;

    [SerializeField]
    Transform shootingPoint;

    [SerializeField]
    float shootingMagnitude;

    [SerializeField]
    float shootingRate;

    bool shootingOrder;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("LaunchProcedure");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine("LaunchProcedure");
        }

    }

    void LaunchBullet()
    {
        GameObject newBullet = Instantiate(bulletModel, shootingPoint.position, shootingPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * shootingMagnitude, ForceMode.Impulse);
    }

    IEnumerator LaunchProcedure()
    {
        Debug.Log("Start Launching.");

        do
        {
            Debug.Log("Launching..........");
            LaunchBullet();

            yield return new WaitForSeconds(shootingRate);

        } while (true);


        Debug.Log("End launching.");
    }

    public void handleFire(CallbackContext ctx)
    {
        shootingOrder = ctx.ReadValue<float>() > 0 ? true : false;
    }
}
