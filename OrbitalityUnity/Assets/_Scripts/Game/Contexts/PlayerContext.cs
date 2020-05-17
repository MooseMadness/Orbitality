using UnityEngine;
using UnityEngine.UI;

namespace Game.Contexts
{
    using Controlls;

    public class PlayerContext : MonoBehaviour
    {
        [SerializeField] Button _fireBtn;

        public PlayerController PlayerController { private set; get; }

        public void Init(PlanetsStorage planetsStorage)
        {
            PlayerController = new PlayerController(planetsStorage.GetPlayerPlanet(), _fireBtn);
            planetsStorage.OnPlayerKilled += PlayerController.Clear;
        }
    }
}