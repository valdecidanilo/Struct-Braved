using System;
using Braved.Runtime.Scripts.Views;
using Interfaces;
using UnityEngine;

namespace Controllers
{
    public class Controller : MonoBehaviour, IController
    {
        private Coroutine _coroutine;
        private View _view;
        public Transform canvas;
        
        private void Awake()
        {
        }
        public void StartController()
        {
            _view = new View(canvas);
        }
    }
}
