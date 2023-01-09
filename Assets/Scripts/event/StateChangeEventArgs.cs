using System;
using state;

namespace @event
{
    public class StateChangeEventArgs : EventArgs
    {
        public State PreviousState { get; set; }
        
        public State NewState { get; set; }
    }
}