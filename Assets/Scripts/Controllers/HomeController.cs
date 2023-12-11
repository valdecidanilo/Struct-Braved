using System;
using Interfaces;
using Models;
using Services;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using Views;

namespace Controllers
{
    public class HomeController : MonoBehaviour, IController
    {
        private Coroutine _coroutine;
        private HomeView _homeView;
        public Transform canvas;
        
        public Action OnOpenBetHistory;
        private void Awake()
        {
            WebFake.OnUpdateUser += OnUpdateUser;
            WebFake.OnBet += ReceiveBet;
            WebFake.IsWin += UpdateUI;
        }
        public void StartController()
        {
            _homeView = new HomeView(canvas);
            _homeView.OnSendBet += SendBet;
            _homeView.OnLeftButtonClicked += () => CheckBetWin(0);
            _homeView.OnRightButtonClicked += () => CheckBetWin(1);
            _homeView.OnOpenBetHistory += () => OnOpenBetHistory?.Invoke();
        }
        private void SendBet()
        {
            if(WebFake.CurrenUser.Balance < 10) return;
            _homeView.Lock();
            _homeView.SetBetInteractable(false);
            _coroutine = StartCoroutine(WebFake.SendBet(10));
        }

        private void UpdateUI(bool isWin)
        {
            _homeView.Lock();
            if(isWin)
                _homeView.OnGain?.Invoke(12);
        }
        private void CheckBetWin(int value)
        {
            _homeView.Lock();
            _homeView.SetBetInteractable(false);
            _coroutine = StartCoroutine(WebFake.CheckWin(value));
        }
        private void OnUpdateUser(User user)
        {
            _homeView.UpdateUser(user);
        }
        private void ReceiveBet()
        {
            _homeView.UnLock();
        }
    }
}
