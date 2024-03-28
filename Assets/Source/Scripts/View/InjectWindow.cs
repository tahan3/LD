using Zenject;

namespace Source.Scripts.View
{
    public abstract class InjectWindow : Window
    {
        [Inject]
        public abstract void Construct(DiContainer container);
    }
}