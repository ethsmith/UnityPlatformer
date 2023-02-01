using api.@event;

namespace game.state
{
    public interface IState
    {
        string Id { get; }

        int Priority { get; }
        
        void Enter();
        
        void Exit();
        
        bool IsReadyForExit();
        
        void SetListeners(params IEventListener[] listeners);
        
        IEventListener[] GetListeners();
    }
}