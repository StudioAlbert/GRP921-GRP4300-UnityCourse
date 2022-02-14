using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurretExercice
{
    public class Target : MonoBehaviour
    {

        private int _lifePoints;

        // Start is called before the first frame update
        void Start()
        {
            _lifePoints = 100;
        }

        // Update is called once per frame
        void Update()
        {
            if (_lifePoints <= 0)
            {
                Destroy(gameObject);
            }

            Debug.Log("Target life points : " + _lifePoints);

        }

        public void DoDamage(int damage)
        {
            _lifePoints -= damage;
        }
    }
}
