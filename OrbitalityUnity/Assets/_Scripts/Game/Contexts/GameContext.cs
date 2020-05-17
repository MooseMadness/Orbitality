using UnityEngine;
using UnityEngine.UI;

namespace Game.Contexts
{
    using GameLoop;
    using Controlls;
    using Damage;

    public class GameContext : MonoBehaviour
    {
        [SerializeField] SunSystemContext _sunSystemContext;
        [SerializeField] GravityContext _gravityContext;
        [SerializeField] FireContext _fireContext;
        [SerializeField] SystemsUpdater _systemsUpdater;
        [Tooltip("Count from 1")]
        [SerializeField] int _playerPlanetNumber;
        [SerializeField] Button _fireBtn;
        [SerializeField] PlanetContext[] _planets;

        private PlayerController _playerController;
        private HealthsContainer _healthsContainer;

        private void Start()
        {
            InitSubContexts();
            InitPlayer();
        }

        private void InitSubContexts()
        {
            _sunSystemContext.Init(_planets);
            _systemsUpdater.AddFrameTicker(_sunSystemContext.OrbitsSystem);
            _gravityContext.Init(_planets);
            InitHealth();

            _fireContext.Init(
                _planets, 
                _gravityContext.GravitySystem, 
                _systemsUpdater,
                _healthsContainer
            );
        }

        private void InitPlayer()
        {
            var playerPlannet = _planets[_playerPlanetNumber - 1];
            _playerController = new PlayerController(playerPlannet, _fireBtn);
        }

        private void InitHealth()
        {
            _healthsContainer = new HealthsContainer();
            foreach (var planet in _planets)
                _healthsContainer.AddHealth(planet.HealthProvider.GetHealth());

            _healthsContainer.OnKilled += _gravityContext.GravitySystem.Remove;
            _healthsContainer.OnKilled += _sunSystemContext.OrbitsSystem.Remove;
            _healthsContainer.OnKilled += RemovePlanet;
        }

        private void RemovePlanet(int id)
        {
            for(int i = 0; i < _planets.Length; i++)
            {
                if (!_planets[i])
                    continue;

                if(id == _planets[i].Id)
                {
                    if (i == _playerPlanetNumber - 1)
                        _playerController.Clear();

                    Destroy(_planets[i].gameObject);
                    _planets[i] = null;
                    break;
                }
            }
        }
    }
}