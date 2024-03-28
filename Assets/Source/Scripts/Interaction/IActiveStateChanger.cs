using System;

namespace Source.Scripts.Interaction
{
    public interface IActiveStateChanger : IEnable, IDisable
    {
        public event Action<bool> OnStateChanged;
    }
}