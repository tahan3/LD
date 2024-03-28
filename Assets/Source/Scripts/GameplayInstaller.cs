using Cysharp.Threading.Tasks;
using Source.Scripts.Data.Gameplay;
using Source.Scripts.Data.Windows;
using Source.Scripts.GameOver;
using Source.Scripts.ObjectsFinder.Clicker;
using Source.Scripts.ObjectsFinder.Finder;
using Source.Scripts.Particles;
using Source.Scripts.Reactive;
using Source.Scripts.SaveLoad;
using Source.Scripts.Timing;
using Source.Scripts.View;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using Timer = Source.Scripts.Timing.Timer;

namespace Source.Scripts
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private Transform levelPrefabParent;
        // это все должно быть в конфигах
        [SerializeField] private AssetReference levelConfig;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private int levelTime;
        
        public override async void InstallBindings()
        {
            // save/load players data
            var playersDataHandler = new JsonPlayerDataHandler();
            
            var objectsCounter = new ReactiveVariable<int>();
            
            var timer = new Timer(levelTime);
            
            var finder = new LayerObjectsFinder(layerMask);
            var clicker = new GameObjectsClicker(finder);

            var particlesHandler = Container.Resolve<IParticlesHandler<ParticleType>>();

            Container.Bind<ITimer<int>>()
                .To<Timer>()
                .FromInstance(timer);
            
            Container.Bind<IPlayerDataHandler<PlayerData>>()
                .To<JsonPlayerDataHandler>()
                .FromInstance(playersDataHandler);
            
            var prefab = await Addressables.InstantiateAsync(levelConfig, levelPrefabParent).ToUniTask();
            var config = prefab.GetComponent<LevelConfig>();
            
            var gameOverHandler = new GameOverHandler(config.hiddenObjects.Count, objectsCounter, timer.Time);
            var windowsHandler = Container.Resolve<IWindowsHandler<WindowType>>();
            
            Container.Bind<IGameOverHandler>()
                .To<GameOverHandler>()
                .FromInstance(gameOverHandler);
            
            clicker.Enable();
            timer.Enable();

            finder.OnObjectFound += (go) =>
            {
                particlesHandler.PlayParticle(ParticleType.HiddenObject, go.transform.position);
                objectsCounter.Value++;
                go.SetActive(false);
            };
            
            gameOverHandler.OnVictory += () =>
            {
                OnGameOver();
                windowsHandler.OpenWindow(WindowType.Victory);
            };
            
            gameOverHandler.OnDefeat += () =>
            {
                OnGameOver();
                windowsHandler.OpenWindow(WindowType.Defeat);
            };
            
            return;

            void OnGameOver()
            {
                clicker.Disable();
                timer.Disable();
                playersDataHandler.Data.Value = new PlayerData()
                {
                    level = playersDataHandler.Data.Value.level + 1,
                };
                playersDataHandler.Save();
            }
        }
    }
}