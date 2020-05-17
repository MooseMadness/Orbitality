using UnityEngine;
using System.Collections.Generic;

namespace Game.Contexts
{
    using Fire;
    using Gravity;
    using GameLoop;
    using Damage;
    using States;

    public class FireContext : MonoBehaviour
    {
        [SerializeField] Transform _rocketsParent;
        [SerializeField] RocketsStorage _rockets;
        [SerializeField] Transform _cameraTransform;

        public RocketsMovementSystem MovementSystem { private set; get; }

        private RocketsFactory _rocketsFactory;

        public void Init(
            IEnumerable<PlanetContext> planets, 
            GravitySystem gravitySystem, 
            SystemsUpdater systemsUpdater,
            HealthsContainer healthsContainer,
            RocketState[] rocketsStates
        )
        {
            MovementSystem = new RocketsMovementSystem(gravitySystem);
            systemsUpdater.AddPhysicsTicker(MovementSystem);
            _rocketsFactory = new RocketsFactory(
                _rockets, 
                MovementSystem, 
                _rocketsParent,
                healthsContainer,
                _cameraTransform
            );
            _rocketsFactory.CreateRockets(rocketsStates);

            foreach (var planet in planets)
            {
                planet.CannonProvider.SetFactory(_rocketsFactory);
                var cannon = planet.CannonProvider.GetCannon();
                systemsUpdater.AddFrameTicker(cannon);
            }
        }
    }
}