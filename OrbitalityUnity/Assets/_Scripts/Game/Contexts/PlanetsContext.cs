using UnityEngine;

namespace Game.Contexts
{
    using States;
    using Planets;

    public class PlanetsContext : MonoBehaviour
    {
        [SerializeField] PlanetContext[] _planetsPrefabs;
        [SerializeField] Transform _planetsRoot;

        public PlanetsStorage PlanetsStorage { private set; get; }

        public void Init(PlanetState[] planetStates)
        {
            PlanetsStorage = new PlanetsStorage(_planetsPrefabs, _planetsRoot, planetStates);
        }
    }
}