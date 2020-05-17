using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Game.Contexts
{
    using Controlls;
    using Planets;
    using GameLoop;
    using Fire;

    public class ControllsContext : MonoBehaviour
    {
        [SerializeField] Range _aiFireInterval;
        [SerializeField] Button _fireBtn;
        [SerializeField] CountdownView _countdownView;

        public PlayerController PlayerController { private set; get; }
        
        public void Init(PlanetsStorage planetsStorage, SystemsUpdater systemsUpdater)
        {
            CreatePlayer(planetsStorage);
            CreateAIs(planetsStorage, systemsUpdater);
        }

        private void CreatePlayer(PlanetsStorage planetsStorage)
        {
            var playerPlanet = planetsStorage.GetPlayerPlanet();
            playerPlanet.CannonProvider.GetCannon().OnTimerChanged += _countdownView.UpdateTime;
            PlayerController = new PlayerController(playerPlanet.CannonProvider.GetCannon(), _fireBtn);
            planetsStorage.OnPlayerKilled += PlayerController.Clear;
        }

        private void CreateAIs(PlanetsStorage planetsStorage, SystemsUpdater systemsUpdater)
        {
            var aiStorage = new AIStorage(
                planetsStorage.GetAIContexts(),
                systemsUpdater,
                _aiFireInterval
            );
        }
    }
}