using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Components
{
    public class HistoryComponent: MonoBehaviour
    {
        public TMP_Text listHistory;
        public Button LoadHistory;
        public Button CloseButton;

        public void Setup(List<(string,int)> history)
        {
            var result = "";
            for (int i = 0; i < history.Count; i++)
            {
                result += $" Jogada {i+1} - lado {history[i].Item1} - ganho : {history[i].Item2} \n";
            }
            listHistory.text = result;
        }
    }
}