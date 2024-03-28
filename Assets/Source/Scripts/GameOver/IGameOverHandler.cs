using System;
using Source.Scripts.Interaction;

namespace Source.Scripts.GameOver
{
    public interface IGameOverHandler
    {
        public event Action OnVictory;
        public event Action OnDefeat;
    }
}