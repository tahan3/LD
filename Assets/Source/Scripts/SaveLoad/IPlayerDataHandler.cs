using System;
using Source.Scripts.Reactive;

namespace Source.Scripts.SaveLoad
{
    public interface IPlayerDataHandler<T> : ILoader<T>, ISaver
    {
        public ReactiveVariable<T> Data { get; }
    }
}