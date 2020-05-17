using UnityEngine;

namespace Game.Contexts
{
    using Damage;
    using Gravity;
    using Orbits;
    using Planets;

    public class HealthsContext : MonoBehaviour
    {
        public HealthsContainer HealthsContainer { private set; get; }

        public void Init(
            GravitySystem gravitySystem, 
            OrbitsSystem orbitsSystem, 
            PlanetsStorage planetsStorage
        )
        {
            HealthsContainer = new HealthsContainer();
            foreach (var planet in planetsStorage.Planets)
                HealthsContainer.AddHealth(planet.HealthProvider.GetHealth());

            HealthsContainer.OnKilled += gravitySystem.Remove;
            HealthsContainer.OnKilled += orbitsSystem.Remove;
            HealthsContainer.OnKilled += planetsStorage.RemovePlanet;
        }
    }
}