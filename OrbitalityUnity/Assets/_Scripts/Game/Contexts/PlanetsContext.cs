using UnityEngine;

namespace Game.Contexts
{
    using States;

    public class PlanetsContext : MonoBehaviour
    {
        [SerializeField] PlanetContext _planetPrefab;
        [SerializeField] Transform _planetsRoot;

        public PlanetsStorage PlanetsStorage { private set; get; }

        public void Init(PlanetState[] planetStates)
        {
            PlanetsStorage = new PlanetsStorage(_planetPrefab, _planetsRoot, planetStates);
        }
    }
}