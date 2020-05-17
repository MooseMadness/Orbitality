﻿using System.Collections.Generic;
using UObject = UnityEngine.Object;
using URandom = UnityEngine.Random;
using System;
using UnityEngine;

namespace Game.Planets
{
    using Contexts;
    using States;

    public class PlanetsStorage
    {
        public Action OnPlayerKilled;
        public Action OnAllEnemiesKilled;
        public OnEnemyKilledHandler OnEnemyKilled;

        public IEnumerable<PlanetContext> Planets => _planets;

        private List<PlanetContext> _planets;
        private int _playerPlanetId;

        public PlanetsStorage(
            PlanetContext[] planetsPrefabs, 
            Transform planetsRoot, 
            PlanetState[] planetsStates,
            Color playerColor,
            Color enemyColor
        )
        {
            _planets = new List<PlanetContext>(planetsStates.Length);
            var prefabs = new List<PlanetContext>(planetsPrefabs);
            foreach(var planetState in planetsStates)
            {
                var rndPrefabIndex = URandom.Range(0, prefabs.Count);
                var planetContext = UObject.Instantiate(prefabs[rndPrefabIndex], planetsRoot);
                prefabs.RemoveAt(rndPrefabIndex);

                var healthProvider = planetContext.HealthProvider;
                healthProvider.StartHp = planetState.CurHealth;
                healthProvider.MaxHp = planetState.MaxHealth;

                var orbitWalkerProvider = planetContext.OrbitWalkerProvider;
                orbitWalkerProvider.OrbitRadius = planetState.OrbitRadius;
                orbitWalkerProvider.StartAngle = planetState.CurAngle;
                orbitWalkerProvider.AngularSpeed = planetState.AngularSpeed;

                planetContext.transform.localRotation = Quaternion.Euler(planetState.Rotation);

                planetContext.HealthProvider.SetColor(enemyColor);

                planetContext.CannonProvider.RocketType = planetState.RocketType;

                _planets.Add(planetContext);
            }

            var rndIndex = URandom.Range(0, _planets.Count);
            var playerPlanet = _planets[rndIndex];
            _playerPlanetId = playerPlanet.Id;
            playerPlanet.HealthProvider.SetColor(playerColor);
        }

        public PlanetContext GetPlayerPlanet()
        {
            foreach(var planet in _planets)
            {
                if (planet.Id == _playerPlanetId)
                    return planet;
            }
            return null; 
        }

        public IEnumerable<PlanetContext> GetAIContexts()
        {
            foreach(var planet in _planets)
            {
                if (planet.Id != _playerPlanetId)
                    yield return planet;
            }
        }

        public void RemovePlanet(int id)
        {
            if (id == _playerPlanetId)
            {
                OnPlayerKilled?.Invoke();
            }
            else
            {
                OnEnemyKilled?.Invoke(id);
            }

            for (int i = 0; i < _planets.Count; i++)
            {
                if (id == _planets[i].Id)
                {
                    UObject.Destroy(_planets[i].gameObject);
                    _planets.RemoveAt(i);
                    break;
                }
            }

            if (_planets.Count == 1 && _planets[0].Id == _playerPlanetId)
                OnAllEnemiesKilled?.Invoke();
        }
    }
}