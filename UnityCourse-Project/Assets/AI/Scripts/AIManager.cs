using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIManager : MonoBehaviour
{

    private List<AIAgent> _agents;
        
    // Start is called before the first frame update
    void Start()
    {
        _agents = FindObjectsOfType<AIAgent>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Debug.Log("Object hit : " + hit.collider.gameObject.name);
                foreach (var aiAgent in _agents)
                {
                    aiAgent.SetDestination(hit.point);
                }
            
            }
        }
    }
}
