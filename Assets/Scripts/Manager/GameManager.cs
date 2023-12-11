using System;
using Controllers;
using Services;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public HomeController homeController;
        public HistoryController historyController;
        
        public State.State state;
        
        public Action openBetHistory;
        private void Awake()
        {
            state = new State.State();
            homeController.StartController();
            homeController.OnOpenBetHistory += OpenBetHistory;
        }

        private void Start()
        {
            StartCoroutine(WebFake.GetUser());
        }

        private void OpenBetHistory()
        {
            historyController.StartController();
        }
    }
}
