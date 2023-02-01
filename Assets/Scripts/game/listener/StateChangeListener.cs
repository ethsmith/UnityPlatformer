using System;
using api.@event;
using game.@event.args;
using game.state;

namespace game.listener
{
    public class StateChangeListener : IEventListener
    {

        private readonly IEvent _event;
        
        public StateChangeListener(IEvent @event)
        {
            _event = @event;
        }

        public IEvent GetEvent()
        {
            return _event;
        }

        public void OnFire(object sender, EventArgs eventArgs)
        {
            if (eventArgs == null) return;
            
            IState state = ((StateChangeEventArgs) eventArgs).NewState;

            if (state.Id == "Init")
            {
                // Spawn enemies

                // Spawn obstacles
            
                // Spawn powerups
            }
        }
    }
}