using UnityEngine;

namespace Source.Scripts.Particles
{
    public interface IParticlesHandler<T>
    {
        public void PlayParticle(T key, Vector3 position);
    }
}