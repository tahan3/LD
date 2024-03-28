using Source.Scripts.Data;
using UnityEngine;

namespace Source.Scripts.Particles
{
    [CreateAssetMenu(fileName = "ParticlesStorage", menuName = "ParticlesStorage", order = 0)]
    public class ParticlesStorage : KeyValueStorage<ParticleType, ParticleSystem>
    {
    }
}