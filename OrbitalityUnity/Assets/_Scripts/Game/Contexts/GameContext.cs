using UnityEngine;

namespace Game.Contexts
{
    using GameLoop;

    public class GameContext : MonoBehaviour
    {
        [SerializeField] SunSystemContext _sunSystemContext;
        [SerializeField] GravityContext _gravityContext;
        [SerializeField] FireContext _fireContext;
        [SerializeField] PlanetsContext _planetsContext;
        [SerializeField] PlayerContext _playerContext;
        [SerializeField] HealthsContext _healthsContext;
        [SerializeField] SystemsUpdater _systemsUpdater;

        private void Start()
        {
            var gameState = ProjectContext.Instance.GameLoader.GameState;

            _planetsContext.Init(gameState.Planets);
            _sunSystemContext.Init(_planetsContext.PlanetsStorage.Planets);
            _systemsUpdater.AddFrameTicker(_sunSystemContext.OrbitsSystem);
            _gravityContext.Init(_planetsContext.PlanetsStorage.Planets);

            _healthsContext.Init(
                _gravityContext.GravitySystem,
                _sunSystemContext.OrbitsSystem,
                _planetsContext.PlanetsStorage
            );

            _fireContext.Init(
                _planetsContext.PlanetsStorage.Planets,
                _gravityContext.GravitySystem,
                _systemsUpdater,
                _healthsContext.HealthsContainer
            );

            _playerContext.Init(_planetsContext.PlanetsStorage);
        }
    }
}