using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class HomeComponent : MonoBehaviour
    {
        public Button LeftButton, RightButton, SendBet, OpenBetHistory;
        public TMP_Text Name, Balance, GainText;
        public Animator GainAnimator;

        private readonly int Push = Animator.StringToHash("Push");
    
        public void SetUser(User user)
        {
            Name.text = user.Name;
            Balance.text = "BRL " + user.Balance;
        }
        public void SetGain(int gain)
        {
            GainText.text = $"BRL + {gain}";
            GainAnimator.SetTrigger(Push);
        }
    }
}
