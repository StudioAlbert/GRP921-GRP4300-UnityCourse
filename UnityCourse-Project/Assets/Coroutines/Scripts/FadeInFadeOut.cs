using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{

    [SerializeField]
    Material mat1;

    [SerializeField]
    Material mat2;

    [SerializeField]
    float stepTime = 0.1f;

    [SerializeField]
    float stepValue = 0.1f;


    IEnumerator fadeRoutine;
    Color fadeColor;

    Color resultColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Renderer>().material.color = resultColor;
    }

    void OnMouseUp()
    {
        if(fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }
        
        if(fadeColor == mat1.color)
        {
            fadeColor = mat2.color;
        }
        else
        {
            fadeColor = mat1.color;
        }

        fadeRoutine = FadetoColor(fadeColor);
        StartCoroutine(fadeRoutine);

    }

    IEnumerator FadetoColor(Color fadeTo)
    {

        float rate = 0.0f;
        Color fadeFrom = this.GetComponent<Renderer>().material.color;

        do
        {

            resultColor = Color.Lerp(fadeFrom, fadeTo, rate);
            rate += stepValue;
            Debug.Log("Rate : " + rate);

            yield return new WaitForSeconds(stepTime);

        } while (rate <= 1.0f);


    }
}
