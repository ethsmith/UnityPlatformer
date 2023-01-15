using System;
using game.@event.args;
using game.state;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace game.@event
{
    public class StateChangeEvent : api.@event.IEvent
    {
        public event EventHandler<StateChangeEventArgs> OnStateChange;
        
        private readonly State _previousState;
        
        private readonly State _newState;
        
        private bool _isCancelled;

        private bool _isCancellable;
        
        public StateChangeEvent(State previousState, State newState)
        {
            _previousState = previousState;
            _newState = newState;
        }

        public void Fire()
        {
            var data = new StateChangeEventArgs
            {
                PreviousState = _previousState,
                NewState = _newState
            };

            OnStateChange?.Invoke(this, data);
        }

        public bool IsCancellable()
        {
            return _isCancellable;
        }

        public bool IsCancelled()
        {
            return _isCancelled;
        }

        public void SetCancelled(bool cancelled)
        {
            _isCancelled = cancelled;
        }
    }
}