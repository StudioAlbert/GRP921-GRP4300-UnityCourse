using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurretExercice
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletModel;
        [SerializeField] private Transform _spawnPoint;

        [SerializeField] private Target _target;
        [SerializeField] private Transform _root;

        [SerializeField] private float _rate = 13;

        [SerializeField] private Animator _animator;
        
        private bool _doShoot = true;

        void Update()
        {

            if (_target != null)
                _root.transform.LookAt(_target.transform);

            if (Input.GetKeyDown(KeyCode.Space))
                StartCoroutine("Shoot");

            if (Input.GetKeyUp(KeyCode.Space))
                StopCoroutine("Shoot");

        }

        IEnumerator Shoot()
        {
            while (true)
            {
                Bullet oneBullet = Instantiate(_bulletModel, _spawnPoint.position, _spawnPoint.rotation);
                oneBullet.turret = this;
                _animator.SetTrigger("DoShoot");
                yield return new WaitForSeconds(1.0f / _rate);
            }
        }
    }
}
