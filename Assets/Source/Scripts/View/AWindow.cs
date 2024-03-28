using UnityEngine;

namespace Source.Scripts.View
{
    public abstract class AWindow : MonoBehaviour, IWindow
    {
        public abstract void Open();

        public abstract void Close();
    }
}