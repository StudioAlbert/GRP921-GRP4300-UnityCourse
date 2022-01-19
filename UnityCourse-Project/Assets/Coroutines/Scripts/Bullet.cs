using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    float lifeTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CheckDead");
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    IEnumerator CheckDead()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
