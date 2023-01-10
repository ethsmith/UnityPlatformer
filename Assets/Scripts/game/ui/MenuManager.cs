using game.@event;
using game.state;
using UnityEngine;

namespace game.ui
{
    public class MenuManager : MonoBehaviour
    {
        public static void OnPlayerButtonClick()
        {
            // Switch States
            EventManager.FireStateChangeEvent(GameManager.GetInstance().CurrentState, State.InGame);
        }
    }
}