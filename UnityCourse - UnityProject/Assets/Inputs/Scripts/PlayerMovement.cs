using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    //SimpleInput input;
    //InputSystem input;
    newInputSystem input;

    [SerializeField]
    float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(input.Movement * Time.deltaTime * moveSpeed);
    }
}
