using System;
using System.Collections.Generic;
using Source.Scripts.Data;
using Source.Scripts.Data.Windows;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Source.Scripts.View
{
    public class WindowsHandler : IWindowsHandler<WindowType>
    {
        private readonly Dictionary<WindowType, AWindow> _windows = new();
        private WindowType _currentWindowType;

        public event Action<WindowType> OnWindowChanged;

        public WindowsHandler(KeyValueStorage<WindowType, AWindow> data, DiContainer container, Transform parent = null)
        {
            foreach (var keyValuePair in data.items)
            {
                AWindow window = Object.Instantiate(keyValuePair.Value, parent);
                window.Close();
                _windows.Add(keyValuePair.Key, window);
                container.Inject(window);
            }
        }
        
        public WindowsHandler(KeyValueStorage<WindowType, AWindow> data, KeyValueStorage<WindowType, AWindow> bgWindows, DiContainer container, Transform parent = null)
        {
            foreach (var keyValuePair in bgWindows.items)
            {
                container.Inject(Object.Instantiate(keyValuePair.Value, parent));
            }

            foreach (var keyValuePair in data.items)
            {
                AWindow window = Object.Instantiate(keyValuePair.Value, parent);
                window.Close();
                _windows.Add(keyValuePair.Key, window);
                container.Inject(window);
            }
        }
        
        public void OpenWindow(WindowType key)
        {
            if (!_windows.ContainsKey(key)) return;

            if (_windows.TryGetValue(_currentWindowType, out var window))
            {
                window.Close();
            }
            
            _windows[key].Open();

            _currentWindowType = key;

            OnWindowChanged?.Invoke(key);
        }
    }
}