using state;

namespace @event.listener
{
    public class StateChangeListener
    {
        public static void OnStageChange(object sender, StateChangeEventArgs eventArgs)
        {
            State state = eventArgs.NewState;
 
            if (state != State.Init) return;
            
            // Spawn enemies
            
            // Spawn obstacles
            
            // Spawn powerups
        }
    }
}