using Interfaces;
using Services;
using UnityEngine;
using Views;

namespace Controllers
{
    public class HistoryController : MonoBehaviour, IController
    {
        private Coroutine _coroutine;
        private HistoryView _historyView;
        public Transform canvas;
        
        public void StartController()
        {
            
            _historyView = new HistoryView(canvas);
            _historyView.onLoadHistory += GetUserHistory;
        }
        private void GetUserHistory()
        {
            _coroutine = StartCoroutine(WebFake.GetUserHistory((list) =>
                {
                    _historyView.UpdateHistory(list);
                }
            ));
        }
        
    }
}
