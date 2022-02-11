using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _wayPoints;
    public List<GameObject> WayPoints => _wayPoints;
}
