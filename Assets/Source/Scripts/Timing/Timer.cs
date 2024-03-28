using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Source.Scripts.Reactive;
using UnityEngine;

namespace Source.Scripts.Timing
{
    public class Timer : ITimer<int>
    {
        private CancellationTokenSource _cancellationToken;

        public event Action<bool> OnStateChanged;
     
        public ReactiveVariable<int> Time { get; private set; }
        
        public Timer(int seconds)
        {
            Time = new ReactiveVariable<int>(seconds);
        }

        public async void Enable()
        {
            OnStateChanged?.Invoke(true);
            
            _cancellationToken = new CancellationTokenSource();
            
            try
            {
                while (Time.Value > 0)
                {
                    await UniTask.WaitForSeconds(1, cancellationToken: _cancellationToken.Token);

                    Time.Value--;
                }

                OnStateChanged?.Invoke(false);
            }
            catch (OperationCanceledException e)
            {
                Debug.Log(e.Message);
                OnStateChanged?.Invoke(false);
            }
        }

        public void Disable()
        {
            _cancellationToken.Cancel();
        }
    }
}