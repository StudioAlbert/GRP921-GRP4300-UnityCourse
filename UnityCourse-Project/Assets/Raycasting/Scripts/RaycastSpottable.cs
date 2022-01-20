using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSpottable : MonoBehaviour
{
    private bool _isSpotted = false;

    private Color startColor;

    [SerializeField]
    private Color spottedColor;

    // Start is called before the first frame update
    void Start()
    {
        startColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isSpotted)
        {
            GetComponent<Renderer>().material.color = spottedColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = startColor;
        }
    }

    public void SpotObject()
    {
        _isSpotted = true;

        StopCoroutine("CheckSpotted");
        StartCoroutine("CheckSpotted");

    }

    IEnumerator CheckSpotted()
    {
        yield return new WaitForSeconds(0.05f);
        _isSpotted = false;
    }
}
