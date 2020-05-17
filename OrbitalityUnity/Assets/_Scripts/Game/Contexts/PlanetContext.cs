using UnityEngine;

namespace Game.Contexts
{
    using Fire;
    using Orbits;
    using Damage;

    public class PlanetContext : MonoBehaviour
    {
        public CannonProvider CannonProvider;
        public OrbitWalkerProvider OrbitWalkerProvider;
        public Rigidbody Rb;
        public HealthProvider HealthProvider;

        public int Id => gameObject.GetInstanceID();
    }
}