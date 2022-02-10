using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

namespace Events
{
    public class RaiseGameEvent : MonoBehaviour
    {
        [SerializeField] private GameEvent Event;

        private void OnCollisionEnter(Collision collision)
        {
            Event.Raise();
        }
    }
}
