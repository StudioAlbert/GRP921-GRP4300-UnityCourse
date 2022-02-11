using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Game Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> _listeners = new List<GameEventListener>();

        public void Raise()
        {
            foreach (var l in _listeners)
                l.OnEventRaised();
        }
        
        public void Register(GameEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);    
        }

        public void UnRegister(GameEventListener listener)
        {
            if(_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}
