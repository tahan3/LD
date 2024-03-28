using System;
using Source.Scripts.Reactive;

namespace Source.Scripts.GameOver
{
    public class GameOverHandler : IGameOverHandler
    {
        public event Action OnVictory;
        public event Action OnDefeat;

        private readonly int _objectsToWin;

        public GameOverHandler(int objectsToWin, ReactiveVariable<int> objectsCounter, ReactiveVariable<int> timer)
        {
            _objectsToWin = objectsToWin;

            objectsCounter.OnValueChanged += VictoryCheck;
            timer.OnValueChanged += DefeatCheck;
        }

        private void VictoryCheck(int objectsFounded)
        {
            if (objectsFounded >= _objectsToWin)
            {
                OnVictory?.Invoke();
            }
        }

        private void DefeatCheck(int time)
        {
            if (time <= 0)
            {
                OnDefeat?.Invoke();
            }
        }
    }
}