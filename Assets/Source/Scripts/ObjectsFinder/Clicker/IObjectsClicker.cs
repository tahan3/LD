using System;
using Source.Scripts.Interaction;

namespace Source.Scripts.ObjectsFinder.Clicker
{
    public interface IObjectsClicker<out T> : IActiveStateChanger
    {
        public event Action<T> OnClick;
    }
}