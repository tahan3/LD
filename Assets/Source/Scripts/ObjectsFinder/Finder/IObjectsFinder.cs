using System;

namespace Source.Scripts.ObjectsFinder.Finder
{
    public interface IObjectsFinder<T>
    {
        public event Action<T> OnObjectFound;

        public bool CheckObject(T suspect);
    }
}