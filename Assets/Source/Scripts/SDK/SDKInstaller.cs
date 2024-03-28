using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Source.Scripts.SDK
{
    public class SDKInstaller : MonoInstaller
    {
        public override async void InstallBindings()
        {
            var appodealHandler = new AppodealHandler("ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy");

            Container.Bind<AppodealHandler>().FromInstance(appodealHandler);
            
            await UniTask.WaitWhile(() => appodealHandler.Status);

            //test
            SceneManager.LoadSceneAsync("MainGameplay");
        }
    }
}