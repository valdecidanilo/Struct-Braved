using System;
using System.Collections.Generic;
using Components;
using Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Utils;

namespace Views
{
    public class HistoryView : IView
    {
        private HistoryComponent historyComponent;
         
        public Action onLoadHistory;
        
        public HistoryView(Transform parent)
        {
            AssetReference asset = new AssetReference(AssetNameReference.HistoryView);
            AsyncOperationHandle<GameObject> handle = asset.InstantiateAsync(parent);
            handle.Completed += OnComplete;
        }
        public void Unload()
        {
            Addressables.ReleaseInstance(historyComponent.gameObject);
        }
        private void OnComplete(AsyncOperationHandle<GameObject> obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject instantiatedObject = obj.Result;
                historyComponent = instantiatedObject.GetComponent<HistoryComponent>();
                historyComponent.CloseButton.onClick.AddListener(() => Unload());
                historyComponent.LoadHistory.onClick.AddListener(() => onLoadHistory?.Invoke());
            }
        }
        public void UpdateHistory(List<(string,int)> list)
        {
            historyComponent.Setup(list);
        }
    }
}