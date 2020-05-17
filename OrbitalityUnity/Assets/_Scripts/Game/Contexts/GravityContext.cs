using UnityEngine;
using System.Collections.Generic;

namespace Game.Contexts
{
    using Gravity;

    public class GravityContext : MonoBehaviour
    {
        [SerializeField] GravitySettings _gravitySettings;
        [SerializeField] Rigidbody _sun;

        public GravitySystem GravitySystem { private set; get; }

        public void Init(IEnumerable<PlanetContext> planets)
        {
            GravitySystem = new GravitySystem(_gravitySettings);

            foreach (var planet in planets)
                GravitySystem.Add(planet.Rb);
            GravitySystem.Add(_sun);
        }
    }
}