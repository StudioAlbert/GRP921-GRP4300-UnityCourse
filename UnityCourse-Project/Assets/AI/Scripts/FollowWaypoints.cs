using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class FollowWaypoints : MonoBehaviour
    {
        [SerializeField] private List<Transform> waypointsInOrder = new List<Transform>();
        [SerializeField] private float MaximumDistance;
        [SerializeField] private float MoveSpeed;
        [SerializeField] private float TurnSpeed;

        private int _currentWPIndex = 0;
            
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(this.transform.position, waypointsInOrder[_currentWPIndex].position) < MaximumDistance)
            {
                _currentWPIndex++;
                
                if (_currentWPIndex >= waypointsInOrder.Count)
                    _currentWPIndex = 0;
                
            }

            Quaternion lookAt =
                Quaternion.LookRotation(waypointsInOrder[_currentWPIndex].position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookAt, TurnSpeed * Time.deltaTime);
            transform.Translate(0, 0, MoveSpeed * Time.deltaTime);

        }
    }
}
