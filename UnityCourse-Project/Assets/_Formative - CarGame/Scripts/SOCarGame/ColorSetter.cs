using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOCarGame
{

    [ExecuteInEditMode]
    public class ColorSetter : MonoBehaviour
    {
        [SerializeField] private VehicleSettings settings;
        [SerializeField] private Material carMaterial;

        // Update is called once per frame
        void Update()
        {
            carMaterial.color = settings.CarColor;
        }
}

}
