using game.@event;
using game.state;
using UnityEngine;

namespace game.ui
{
    public class MenuManager : MonoBehaviour
    {
        private static GameManager gameManager = GameManager.GetInstance();
        
        private static StateController stateController = gameManager.GetStateController();
        
        public static void OnPlayerButtonClick()
        {
            // Switch States
            EventManager.FireStateChangeEvent(stateController.CurrentState, stateController.GetState("Init"));
        }
    }
}