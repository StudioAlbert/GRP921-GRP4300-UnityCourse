using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOCarGame
{
    [CreateAssetMenu(fileName = "New Float Value", menuName = "Car Game/Float Value")]
    public class SOFloatValue : ScriptableObject
    {
        public void Awake()
        {
            Debug.Log("Scriptable float value start");
            Value = 0;
        }    
        public void Reset()
        {
            Debug.Log("Scriptable float value reset");
            Value = 0;
        }
        public float Value;
    }
}
