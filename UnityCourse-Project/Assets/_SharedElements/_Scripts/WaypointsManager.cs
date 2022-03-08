using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _wayPoints;

    private int _currentPatrolIndex = 0;
    public List<GameObject> WayPoints => _wayPoints;

    public GameObject GetNextPatrolDestination()
    {
        _currentPatrolIndex++;
        if (_currentPatrolIndex >= _wayPoints.Count)
            _currentPatrolIndex = 0;

        return GetCurrentDestination();
        
    }
    public GameObject GetCurrentDestination()
    {
        return _wayPoints[_currentPatrolIndex];
    }
}
