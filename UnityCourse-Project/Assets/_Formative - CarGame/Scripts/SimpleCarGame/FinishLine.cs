using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCarGame
{
    public class FinishLine : MonoBehaviour
    {
        // 
        [SerializeField] GameManager gameManager;

        private void OnTriggerEnter(Collider other)
        {
            gameManager.OnLapChanged();
        }
    }
}
