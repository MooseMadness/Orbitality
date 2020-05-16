using UnityEngine;

namespace Game.Contexts
{
    using Fire;
    using Orbits;

    public class PlanetContext : MonoBehaviour
    {
        public CannonProvider CannonProvider;
        public OrbitWalkerProvider OrbitWalkerProvider;
        public Rigidbody Rb;
    }
}