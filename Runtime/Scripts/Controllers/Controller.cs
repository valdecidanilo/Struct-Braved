using Braved.Views;
using Braved.Interfaces;
using UnityEngine;

namespace Braved.Controllers
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
