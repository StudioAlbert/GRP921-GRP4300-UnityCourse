using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GameEventListener : MonoBehaviour
    {

        [SerializeField] private GameEvent Event;
        [SerializeField] public UnityEvent Response;

        private void OnEnable()
        {
            Event.Register(this);
        }

        private void OnDisable()
        {
            Event.UnRegister(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}
