using DG.Tweening;
using Source.Scripts.SDK;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Source.Scripts.View.GameplayWindows
{
    public class GameOverWindow : InjectWindow
    {
        [Header("Buttons")]
        [SerializeField] private Button restartButton;
        
        [Header("Settings")]
        [SerializeField] private float scaleDuration;
        
        public override void Construct(DiContainer container)
        {
            var appodealHandler = container.Resolve<AppodealHandler>();
            
            restartButton.onClick.AddListener(() =>
            {
                AppMetrica.Instance.ReportEvent("RESTART_EVENT");
                appodealHandler.ShowInterstitial();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        }

        public override void Open()
        {
            transform.localScale = Vector3.zero;
            base.Open();
            transform.DOScale(Vector3.one, scaleDuration);
        }
    }
}