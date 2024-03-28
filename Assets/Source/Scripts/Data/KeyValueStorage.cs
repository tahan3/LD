using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Source.Scripts.Data
{
    public abstract class KeyValueStorage<TKey, TValue> : ScriptableObject
    {
        public SerializedDictionary<TKey, TValue> items;
    }
}