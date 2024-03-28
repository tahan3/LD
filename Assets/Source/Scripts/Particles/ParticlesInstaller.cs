using Source.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Source.Scripts.Particles
{
    public class ParticlesInstaller : MonoInstaller
    {
        [SerializeField] private KeyValueStorage<ParticleType, ParticleSystem> particlesStorage;
        
        public override void InstallBindings()
        {
            ParticlesHandler particlesHandler = new ParticlesHandler(particlesStorage, Container, transform);

            Container.Bind<IParticlesHandler<ParticleType>>().FromInstance(particlesHandler).AsSingle();
        }
    }
}