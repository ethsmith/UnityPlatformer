using @event;
using state;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ui
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