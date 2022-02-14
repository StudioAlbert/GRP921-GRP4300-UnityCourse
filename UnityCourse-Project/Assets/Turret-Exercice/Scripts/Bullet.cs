using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurretExercice
{
    public class Bullet : MonoBehaviour
    {
        public Turret turret;

        [SerializeField] private float speed = 5.0f;
        [SerializeField] private float range = 100.0f;

        private void Update()
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);

            if (Vector3.Distance(gameObject.transform.position, turret.gameObject.transform.position) > range)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            Target target = other.gameObject.GetComponent<Target>();
            if (target != null)
            {
                Debug.Log("Doing damages !");
                target.DoDamage(5);
                Destroy(gameObject);
            }

        }
    }

}