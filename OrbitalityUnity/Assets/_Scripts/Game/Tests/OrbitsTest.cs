using UnityEngine;

namespace Game.Tests
{
    using Orbits;

    public class OrbitsTest : MonoBehaviour
    {
        [SerializeField] Transform _sun;
        [SerializeField] OrbitWalkerProvider[] _planets;

        private OrbitsSystem _orbitsSystem;

        private void Start()
        {
            _orbitsSystem = new OrbitsSystem(_sun.transform.localPosition);
            foreach (var planet in _planets)
                _orbitsSystem.Add(planet.GetOrbitWalker());
            _orbitsSystem.Tick(0);
        }

        private void Update()
        {
            _orbitsSystem.Tick(Time.deltaTime);
        }
    }
}