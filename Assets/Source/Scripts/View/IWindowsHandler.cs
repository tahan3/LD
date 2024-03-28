using System;

namespace Source.Scripts.View
{
    public interface IWindowsHandler<T>
    {
        public event Action<T> OnWindowChanged;
        public void OpenWindow(T key);
    }
}