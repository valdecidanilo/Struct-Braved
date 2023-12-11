using System;
using Components;
using Interfaces;
using Models;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Utils;

namespace Views
{
    public class HomeView : IView
    {
        private HomeComponent Component;

        public Action OnLeftButtonClicked, OnRightButtonClicked, 
            OnSendBet, OnOpenBetHistory;

        public Action<int> OnGain;
        
        public HomeView(Transform parent)
        {
            AssetReference asset = new AssetReference(AssetNameReference.HomeView);
            AsyncOperationHandle<GameObject> handle = asset.InstantiateAsync(parent);
            handle.Completed += OnComplete;
        }
        public void OnComplete(AsyncOperationHandle<GameObject> obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject instantiatedObject = obj.Result;
                Component = instantiatedObject.GetComponent<HomeComponent>();
                Component.LeftButton.onClick.AddListener(() => OnLeftButtonClicked?.Invoke());
                Component.RightButton.onClick.AddListener(() => OnRightButtonClicked?.Invoke());
                Component.SendBet.onClick.AddListener(() => OnSendBet?.Invoke());
                Component.OpenBetHistory.onClick.AddListener(() => OnOpenBetHistory?.Invoke());
                OnGain += SetGain;
            }
        }

        private void SetGain(int gain)
        {
            Component.SetGain(gain);
        }
        public void UpdateUser(User user)
        {
            Component.SetUser(user);
        }
        public void Lock()
        {
            Component.LeftButton.interactable = false;
            Component.RightButton.interactable = false;
            SetBetInteractable(true);
        }
        public void UnLock()
        {
            Component.LeftButton.interactable = true;
            Component.RightButton.interactable = true;
            SetBetInteractable(false);
        }
        
        public void SetBetInteractable(bool value)
        {
            Component.SendBet.interactable = value;
        }
        public void Unload()
        {
            Addressables.ReleaseInstance(Component.gameObject);
        }
    }
}