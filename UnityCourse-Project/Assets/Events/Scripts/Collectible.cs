using System;
using UnityEngine;

namespace Events
{
    public class Collectible : MonoBehaviour
    {

        public event Action<Collectible> OnPickup;
        
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision with : " + collision.gameObject.name);
            
            OnPickup?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
    
}
