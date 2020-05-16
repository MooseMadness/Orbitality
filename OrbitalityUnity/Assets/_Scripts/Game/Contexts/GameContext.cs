using UnityEngine;
using UnityEngine.UI;

namespace Game.Contexts
{
    using GameLoop;
    using Controlls;

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
            _fireContext.Init(_planets, _gravityContext.GravitySystem, _systemsUpdater);
        }

        private void InitPlayer()
        {
            var playerPlannet = _planets[_playerPlanetNumber - 1];
            _playerController = new PlayerController(playerPlannet, _fireBtn);
        }
    }
}