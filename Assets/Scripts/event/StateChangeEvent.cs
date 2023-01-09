using System;
using state;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace @event
{
    public class StateChangeEvent
    {
        public event EventHandler<StateChangeEventArgs> OnStateChange;
        
        private readonly State _previousState;
        
        private readonly State _newState;
        
        public StateChangeEvent(State previousState, State newState)
        {
            _previousState = previousState;
            _newState = newState;
        }

        public void Fire()
        {
            var data = new StateChangeEventArgs();

            try
            {
                Debug.Log("State changed, handling event...");

                data.PreviousState = _previousState;
                data.NewState = _newState;
                
                SceneManager.LoadScene(_newState.GetLevelToLoad());
                
                OnComplete(data);
            } catch (Exception e)
            {
                Debug.Log("Error occurred while handling event: " + e.Message);
            }
        }

        protected virtual void OnComplete(StateChangeEventArgs e)
        {
            OnStateChange?.Invoke(this, e);
        }
    }
}