namespace game.state
{
    public enum State
    {
        Menu,

        Init,

        InGame,

        EndGame
    }

    static class StateManager
    {
        public static string GetLevelToLoad(this State currentState)
        {
            return currentState switch
            {
                State.Menu => "Menu",
                State.Init => "Loading",
                State.InGame => "Main",
                State.EndGame => "GameOver",
                _ => "Error"
            };
        }
    }
}