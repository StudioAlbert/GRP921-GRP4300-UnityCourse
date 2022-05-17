using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_Wander: SteeringBehaviour
{

    [Header("Seeking")]
    // the target
    // The steered object will follow seek, follow, evade from, hide from the target
    // [SerializeField] private Target _targetToSeek;
    [SerializeField] private float _wanderSpeed;
    // [SerializeField] private float _maxDistance;

    [SerializeField] private float _wanderDistance;
    [SerializeField] private float _wanderRadius;
    [SerializeField] private float _wanderJitterAngleMax;
    [SerializeField] private float _wanderJitterAngleMin;
    
    private float _wanderAngle;
    private Vector3 _wanderPoint;
    private Vector3 _wanderCenter;

    protected override void UpdateSteering()
    {
        Debug.Log("Bot wandering");
        //_wanderAngle += _wanderJitterAngle;
        _wanderAngle += Random.Range(_wanderJitterAngleMin, _wanderJitterAngleMax);
        _wanderCenter = transform.position + transform.forward * _wanderDistance;
        // _wanderPoint = _wanderCenter + _wanderRadius * new Vector3(Mathf.Sin(Mathf.Deg2Rad * _wanderAngle), 0, Mathf.Cos(Mathf.Deg2Rad * _wanderAngle));
        _wanderPoint = _wanderCenter + _wanderRadius * new Vector3(Mathf.Sin(Mathf.Deg2Rad * _wanderAngle), 0, Mathf.Cos(Mathf.Deg2Rad * _wanderAngle)).normalized;
        
        DesiredVelocity = (_wanderPoint - transform.position).normalized * _wanderSpeed;
        
        // if(Vector3.Distance(_targetToSeek.transform.position, transform.position) > _maxDistance)
        //     // Not close enough, seek
        //     DesiredVelocity = (_wanderPoint - transform.position).normalized * _wanderSpeed;
        // else
        //     DesiredVelocity = Vector3.zero;
            
    }

    protected override void DrawGizmos()
    {
        float size = 2f;
        
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(_wanderPoint, new Vector3(size, size, size));
        //Gizmos.DrawCube(_wanderCenter, new Vector3(0.5f, 0.5f, 0.5f));
        Gizmos.DrawWireSphere(_wanderCenter, Vector3.Distance(_wanderCenter, _wanderPoint));
    }

}
