using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    private NavMeshAgent _agent;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent<NavMeshAgent>(out _agent))
            Debug.LogError("No nav mesh agent component.");
        
    }

    public void SetDestination(Vector3 targetPosition)
    {
        if (_agent != null)
            _agent.SetDestination(targetPosition);
        else
            Debug.LogError("No nav mesh agent component.");
        
    }

}
