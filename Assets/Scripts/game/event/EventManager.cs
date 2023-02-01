using System;
using game.listener;
using game.state;
using UnityEngine;

namespace game.@event
{
    public class EventManager
    {
        public static void FireStateChangeEvent(IState previousState, IState newState)
        {
            StateChangeEvent stateChangeEvent = new StateChangeEvent(previousState, newState);
            stateChangeEvent.Handler += new StateChangeListener(stateChangeEvent).OnFire;
            stateChangeEvent.Handler += LogEventCompleted;
            stateChangeEvent.Fire();
        }

        private static void LogEventCompleted(object sender, EventArgs eventArgs)
        {
            Debug.Log("Event handling complete!");
        }
    }
}