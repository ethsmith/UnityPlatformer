using System.Collections.Generic;
using UnityEngine;

namespace game.state
{
    public class StateController : MonoBehaviour
    {
        private List<IState> states = new();
        
        public IState CurrentState { get; private set; }
        
        public void AddState(IState state)
        {
            states.Add(state);
        }
        
        public void RemoveState(IState state)
        {
            states.Remove(state);
        }
        
        public void SetState(IState state)
        {
            if (CurrentState != null && CurrentState.IsReadyForExit())
            {
                CurrentState.Exit();
                UnregisterListeners();
            }
            
            CurrentState = state;
            CurrentState.Enter();
            RegisterListeners();
            
            Debug.Log($"Current state: {CurrentState.GetType().Name}");
        }

        public IState GetState(string id) => states.Find(state => state.Id == id);

        private void RegisterListeners()
        {
            foreach (var eventListener in CurrentState.GetListeners())
            {
                eventListener.GetEvent().Handler += eventListener.OnFire;
            }
        }
        
        private void UnregisterListeners()
        {
            foreach (var eventListener in CurrentState.GetListeners())
            {
                eventListener.GetEvent().Handler -= eventListener.OnFire;
            }
        }
    }
}