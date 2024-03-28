using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Source.Scripts.ObjectsFinder.Finder;
using UnityEngine;

namespace Source.Scripts.ObjectsFinder.Clicker
{
    public class GameObjectsClicker : IObjectsClicker<GameObject>
    {
        public event Action<bool> OnStateChanged;
        
        public event Action<GameObject> OnClick;

        private readonly IObjectsFinder<GameObject> _objectsFinder;

        private CancellationTokenSource _cancellationToken;
        
        public GameObjectsClicker(IObjectsFinder<GameObject> objectsFinder)
        {
            _objectsFinder = objectsFinder;
        }
        
        public void Enable()
        {
            _cancellationToken?.Cancel();

            _cancellationToken = new CancellationTokenSource();
            ClickLoop().ToCancellationToken(_cancellationToken.Token);
        }

        public void Disable()
        {
            if (_cancellationToken == null) return;
            
            _cancellationToken.Cancel();
            OnStateChanged?.Invoke(false);
        }

        private async UniTask ClickLoop()
        {
            var camera = Camera.main == null ? Camera.current : Camera.main;
            
            while (!_cancellationToken.IsCancellationRequested)
            {
                await UniTask.Yield();

                if (Input.GetMouseButtonDown(0))
                {
                    var hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
                    
                    if (hit.collider)
                    {
                        _objectsFinder.CheckObject(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}