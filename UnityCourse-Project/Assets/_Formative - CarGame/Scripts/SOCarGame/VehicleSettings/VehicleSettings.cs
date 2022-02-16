using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOCarGame
{
    [CreateAssetMenu(fileName = "New Vehicle Settings", menuName = "Car Game/Vehicle Settings")] 
    public class VehicleSettings : ScriptableObject
    {
        public  Color CarColor;
        
        public  float turnForce;
        public  float accelerateForce;
        public  float brakeForce;
        public  float gravityForce = 25f;

        public  float speedMax;

        public float mass;
        public float drag;
        public float angularDrag;

        public float GetSpeedMax()
        {
            return Random.Range(5f, 10f);
        }

    }
}
