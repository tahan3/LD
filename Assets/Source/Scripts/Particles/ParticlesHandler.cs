using System.Collections.Generic;
using Source.Scripts.Data;
using Source.Scripts.Pool;
using UnityEngine;
using Zenject;

namespace Source.Scripts.Particles
{
    public class ParticlesHandler : IParticlesHandler<ParticleType>
    {
        private readonly Dictionary<ParticleType, IPool<ParticleSystem>> _particlesPools;

        public ParticlesHandler(KeyValueStorage<ParticleType, ParticleSystem> particlesStorage, DiContainer container,
            Transform parent = null, int initialPoolSize = 5)
        {
            _particlesPools = new Dictionary<ParticleType, IPool<ParticleSystem>>();

            foreach (var item in particlesStorage.items)
            {
                _particlesPools.Add(item.Key,
                    new ParticlesPool(container, item.Value, initialPoolSize, parent));
            }
        }

        public void PlayParticle(ParticleType key, Vector3 position)
        {
            var item = _particlesPools[key].GetItem();
            item.transform.position = position;
            item.Play();
        }
    }
}