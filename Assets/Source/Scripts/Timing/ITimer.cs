using Source.Scripts.Interaction;
using Source.Scripts.Reactive;

namespace Source.Scripts.Timing
{
    public interface ITimer<T> : IActiveStateChanger
    {
        public ReactiveVariable<T> Time { get; }
    }
}