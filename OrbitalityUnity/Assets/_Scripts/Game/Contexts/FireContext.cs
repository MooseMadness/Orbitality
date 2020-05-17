using UnityEngine;
using System.Collections.Generic;

namespace Game.Contexts
{
    using Fire;
    using Gravity;
    using GameLoop;
    using Damage;

    public class FireContext : MonoBehaviour
    {
        [SerializeField] Transform _rocketsParent;
        [SerializeField] RocketsStorage _rockets;
        [SerializeField] Transform _cameraTransform;

        private RocketsMovementSystem _movementSystem;
        private RocketsFactory _rocketsFactory;

        public void Init(
            IEnumerable<PlanetContext> planets, 
            GravitySystem gravitySystem, 
            SystemsUpdater systemsUpdater,
            HealthsContainer healthsContainer
        )
        {
            _movementSystem = new RocketsMovementSystem(gravitySystem);
            systemsUpdater.AddPhysicsTicker(_movementSystem);
            _rocketsFactory = new RocketsFactory(
                _rockets, 
                _movementSystem, 
                _rocketsParent,
                healthsContainer,
                _cameraTransform
            );

            foreach (var planet in planets)
            {
                planet.CannonProvider.SetFactory(_rocketsFactory);
                var cannon = planet.CannonProvider.GetCannon();
                systemsUpdater.AddFrameTicker(cannon);
            }
        }
    }
}