    using UnityEngine;
    using UnityEngine.AI;

    namespace FSM
    {
         public class FSM_State_Patrol : FSM_IState
         {

            private FSM_Tank _tank;

            private readonly WaypointsManager _waypointsManager;
            // private readonly NavMeshAgent _navMeshAgent;
            private readonly Animator _tankAnimator;
            
            private const float MAX_DISTANCE = 1f;
            private const float PATROL_SPEED = 3.5f;

            public FSM_State_Patrol(FSM_Tank tank, WaypointsManager waypointsManager, Animator tankAnimator)
            {
                _tank = tank;
                _waypointsManager = waypointsManager;
                // _navMeshAgent = navMeshAgent;
                _tankAnimator = tankAnimator;
            }
            
            public void OnEnter()
            {
                Debug.Log("Patrol enter");
                _tank.Speed = PATROL_SPEED;
                _tank.Destination = _waypointsManager.GetCurrentDestination().transform.position;
                _tankAnimator.Play("Patrol");
                _tank.StartTargetting();
            }

            public void OnExit()
            {
                Debug.Log("Patrol exit");
                _tank.StopTargetting();
            }

            public void Tick()
            {
                Debug.Log("Patrol tick");

                if (Vector3.Distance(_tank.transform.position, _tank.Destination) <= MAX_DISTANCE)
                    _tank.Destination = _waypointsManager.GetNextPatrolDestination().transform.position;

                // _tank.CheckTargetting();

            }

         }
    }

