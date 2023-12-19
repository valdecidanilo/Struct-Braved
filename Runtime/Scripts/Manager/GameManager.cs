using Controllers;
using UnityEngine;

namespace Braved.Runtime.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public Controller controller;
        
        public State.State state;
        
        private void Awake()
        {
            state = new State.State();
            controller.StartController();
        }
    }
}
