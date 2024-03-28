using System;
using UnityEngine;

namespace Source.Scripts.ObjectsFinder.Finder
{
    public class LayerObjectsFinder : IObjectsFinder<GameObject>
    {
        private readonly int _compareMask;

        public event Action<GameObject> OnObjectFound;
        
        public LayerObjectsFinder(LayerMask compareMask)
        {
            _compareMask = compareMask.value;
        }
        
        public LayerObjectsFinder(int compareMask)
        {
            _compareMask = compareMask;
        }
        
        public bool CheckObject(GameObject suspect)
        {
            if (_compareMask != 1 << suspect.layer) return false;
            
            OnObjectFound?.Invoke(suspect);
            
            return true;
        }
    }
}