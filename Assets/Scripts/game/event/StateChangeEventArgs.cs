using System;
using game.state;

namespace game.@event
{
    public class StateChangeEventArgs : EventArgs
    {
        public State PreviousState { get; set; }
        
        public State NewState { get; set; }
    }
}