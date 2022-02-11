using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private WaypointsManager wpManager;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _wpDistance = 3f;
    [SerializeField] private float _turnSpeed = 0;
   
    private int _currentWP = 0;
    void Update()
    {
        if (Vector3.Distance(transform.position, wpManager.WayPoints[_currentWP].transform.position) < _wpDistance)
        {
            _currentWP++;

            if (_currentWP >= wpManager.WayPoints.Count)
            {
                _currentWP = 0;
            }
        }
        
        //transform.LookAt(wpManager.WayPoints[_currentWP].transform.position);
        Quaternion lookAt =
            Quaternion.LookRotation(wpManager.WayPoints[_currentWP].transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAt, _turnSpeed * Time.deltaTime);
        
        transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed);
        
    }
}
