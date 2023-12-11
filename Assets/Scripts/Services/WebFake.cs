using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services
{
    public class WebFake
    {
        public static User CurrenUser = new();
        public static Action<User> OnUpdateUser;
        public static Action OnBet;
        public static Action<bool> IsWin;
        public static IEnumerator GetUser(Action<User> user = null)
        {
            yield return new WaitForSeconds(.2f);
            CurrenUser = new User
            {
                Name = "Fake User", 
                Balance = 100
            };
            OnUpdateUser?.Invoke(CurrenUser);
            user?.Invoke(CurrenUser);
        }
        public static IEnumerator SendBet(int amountBet, Action<User> user = null)
        {
            if(amountBet > CurrenUser.Balance)
            {
                yield break;
            }
            yield return new WaitForSeconds(.2f);
            CurrenUser.Balance = CurrenUser.Balance - amountBet;
            CurrenUser.CurrentState = State.State.StateModel.Betting;
            yield return new WaitForSeconds(.2f);
            
            yield return GetHand();
            user?.Invoke(CurrenUser);
            OnBet?.Invoke();
        }
        public static IEnumerator CheckWin(int handBet)
        {
            yield return new WaitForSeconds(.2f);
            var isWin = CurrenUser.Hand == handBet;
            CurrenUser.Balance = CurrenUser.Balance + (isWin ? 12 : 0);
            CurrenUser.CurrentState = State.State.StateModel.Spectate;
            OnUpdateUser?.Invoke(CurrenUser);
            yield return SetUserHistory(CurrenUser.Name, isWin ? 12 : 0);
            IsWin?.Invoke(isWin);
        }
        public static IEnumerator SetUserHistory(string name, int amount)
        {
            yield return new WaitForSeconds(.2f);
            CurrenUser.History.Add((name, amount));
            OnUpdateUser?.Invoke(CurrenUser);
        }
        public static IEnumerator GetUserHistory(Action<List<(string,int)>> history = null)
        {
            yield return new WaitForSeconds(.2f);
            history?.Invoke(CurrenUser.History);
        }
        public static IEnumerator GetHand(Action<int> hand = null)
        {
            yield return new WaitForSeconds(.2f);
            var newHand = Random.Range(0, 2);
            hand?.Invoke(newHand);
            yield return new WaitForSeconds(.2f);
            CurrenUser.Hand = newHand;
            OnUpdateUser?.Invoke(CurrenUser);
        }
    }
}