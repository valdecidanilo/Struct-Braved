using Interfaces;
using UnityEngine;

namespace Braved.Runtime.Scripts.Views
{
    public class View : IView
    {
        private Component _component;
        
        public View(Transform parent)
        {
            /*
            var asset = new AssetReference(AssetNameReference.HomeView);
            var handle = asset.InstantiateAsync(parent);
            handle.Completed += OnComplete;
            */
        }

        private void OnComplete()
        {
            /*
            if (obj.Status != AsyncOperationStatus.Succeeded) return;
            var instantiatedObject = obj.Result;
            _component = instantiatedObject.GetComponent<Component>();
            */
        }
        public void Unload()
        {
            //Addressables.ReleaseInstance(_component.gameObject);
        }
    }
}