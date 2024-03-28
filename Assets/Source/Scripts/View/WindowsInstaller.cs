using Source.Scripts.Data;
using Source.Scripts.Data.Windows;
using Source.Scripts.GameOver;
using UnityEngine;
using Zenject;

namespace Source.Scripts.View
{
    public class WindowsInstaller : MonoInstaller
    {
        [Header("Data")]
        [SerializeField] private KeyValueStorage<WindowType, AWindow> bgWindows;
        [SerializeField] private KeyValueStorage<WindowType, AWindow> windows;
        
        [Header("Container")]
        [SerializeField] private Transform parent;

        public override void InstallBindings()
        {
            var windowsHandler = new WindowsHandler(windows, bgWindows, Container, parent);

            Container.Bind<IWindowsHandler<WindowType>>().To<WindowsHandler>().FromInstance(windowsHandler).AsSingle();
        }
    }
}