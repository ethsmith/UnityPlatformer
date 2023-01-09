using System;
using @event.listener;
using state;
using UnityEngine;

namespace @event
{
    public class EventManager
    {
        public static void FireStateChangeEvent(State previousState, State newState)
        {
            StateChangeEvent stateChangeEvent = new StateChangeEvent(previousState, newState);
            stateChangeEvent.OnStateChange += StateChangeListener.OnStageChange;
            stateChangeEvent.OnStateChange += LogEventCompleted;
            stateChangeEvent.Fire();
        }

        private static void LogEventCompleted(object sender, EventArgs eventArgs)
        {
            Debug.Log("Event handling complete!");
        }
    }
}