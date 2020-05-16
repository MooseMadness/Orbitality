using UnityEngine;
using System.Collections.Generic;

namespace Game.Contexts
{
    using Orbits;

    public class SunSystemContext : MonoBehaviour
    {
        [SerializeField] Transform _sun;
        
        public OrbitsSystem OrbitsSystem { get; private set; }

        public void Init(IEnumerable<PlanetContext> planets)
        {
            OrbitsSystem = new OrbitsSystem(_sun.localPosition);
            foreach (var planet in planets)
                OrbitsSystem.Add(planet.OrbitWalkerProvider.GetOrbitWalker());
            OrbitsSystem.Tick(0);
        }
    }
}