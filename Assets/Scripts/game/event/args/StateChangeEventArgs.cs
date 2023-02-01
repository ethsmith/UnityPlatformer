using System;
using game.state;

namespace game.@event.args
{
    public class StateChangeEventArgs : EventArgs
    {
        public IState PreviousState { get; set; }
        
        public IState NewState { get; set; }
    }
}