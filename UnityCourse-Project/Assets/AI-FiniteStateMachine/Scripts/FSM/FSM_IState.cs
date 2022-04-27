using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public interface FSM_IState
    {
        void OnEnter();
        void OnExit();
        void Tick();
    }
}
