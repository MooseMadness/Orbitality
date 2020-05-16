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
            int index = 0;
            foreach (var planet in planets)
            {
                if(index != 1)
                    GravitySystem.Add(planet.Rb);
                index++;
            }
            GravitySystem.Add(_sun);
        }
    }
}