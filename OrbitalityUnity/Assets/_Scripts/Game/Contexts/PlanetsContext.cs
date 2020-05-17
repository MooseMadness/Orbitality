using UnityEngine;

namespace Game.Contexts
{
    using States;
    using Planets;

    public class PlanetsContext : MonoBehaviour
    {
        [SerializeField] Transform _planetsRoot;
        [SerializeField] Color _playerColor;
        [SerializeField] Color _enemyColor;
        [SerializeField] PlanetContext[] _planetsPrefabs;

        public PlanetsStorage PlanetsStorage { private set; get; }

        public void Init(PlanetState[] planetStates)
        {
            PlanetsStorage = new PlanetsStorage(
                _planetsPrefabs, 
                _planetsRoot, 
                planetStates,
                _playerColor,
                _enemyColor
            );
        }
    }
}