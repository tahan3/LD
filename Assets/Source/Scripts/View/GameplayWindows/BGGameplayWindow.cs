using System;
using Source.Scripts.SaveLoad;
using Source.Scripts.Timing;
using TMPro;
using Zenject;

namespace Source.Scripts.View.GameplayWindows
{
    public class BGGameplayWindow : InjectWindow
    {
        public TextMeshProUGUI timerText;
        public TextMeshProUGUI levelText;
        
        public override void Construct(DiContainer container)
        {
            container.TryResolve<ITimer<int>>().Time.OnValueChanged += SetTimer;
            SetLevel(container.TryResolve<IPlayerDataHandler<PlayerData>>().Data.Value.level);
        }

        private void SetLevel(int levelIndex)
        {
            levelText.text = "Level: " + (levelIndex + 1).ToString();
        }
        
        private void SetTimer(int seconds)
        {
            var time = TimeSpan.FromSeconds(seconds);
            timerText.text = time.ToString(@"mm\:ss");
        }
    }
}