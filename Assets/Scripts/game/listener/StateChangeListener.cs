using api.@event;
using game.@event;
using game.@event.args;
using game.state;

namespace game.listener
{
    public class StateChangeListener : IEventListener
    {
        public static void OnStageChange(object sender, StateChangeEventArgs eventArgs)
        {
            State state = eventArgs.NewState;

            if (state == State.Init)
            {
                // Spawn enemies

                // Spawn obstacles
            
                // Spawn powerups
            }
        }
    }
}