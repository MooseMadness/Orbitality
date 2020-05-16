﻿using UnityEngine;
using System.Collections.Generic;

namespace Game.Contexts
{
    using Fire;
    using Gravity;
    using GameLoop;

    public class FireContext : MonoBehaviour
    {
        [SerializeField] Transform _rocketsParent;
        [SerializeField] RocketsStorage _rockets;

        private RocketsMovementSystem _movementSystem;
        private RocketsFactory _rocketsFactory;

        public void Init(
            IEnumerable<PlanetContext> planets, 
            GravitySystem gravitySystem, 
            SystemsUpdater systemsUpdater
        )
        {
            _movementSystem = new RocketsMovementSystem(gravitySystem);
            systemsUpdater.AddPhysicsTicker(_movementSystem);
            _rocketsFactory = new RocketsFactory(_rockets, _movementSystem, _rocketsParent);

            foreach (var planet in planets)
            {
                planet.CannonProvider.SetFactory(_rocketsFactory);
                var cannon = planet.CannonProvider.GetCannon();
                systemsUpdater.AddFrameTicker(cannon);
            }
        }
    }
}