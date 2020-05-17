using System.Collections.Generic;
using UObject = UnityEngine.Object;
using URandom = UnityEngine.Random;
using System;
using UnityEngine;

namespace Game
{
    using Contexts;
    using States;

    public class PlanetsStorage
    {
        public Action OnPlayerKilled;
        public Action OnAllEnemiesKilled;

        public IEnumerable<PlanetContext> Planets => _planets;

        private List<PlanetContext> _planets;
        private int _playerPlanetId;

        public PlanetsStorage(PlanetContext planetPrefab, Transform planetsRoot, PlanetState[] planetsStates)
        {
            _planets = new List<PlanetContext>(planetsStates.Length);
            foreach(var planetState in planetsStates)
            {
                var planetContext = UObject.Instantiate(planetPrefab, planetsRoot);

                var healthProvider = planetContext.HealthProvider;
                healthProvider.StartHp = planetState.CurHealth;
                healthProvider.MaxHp = planetState.MaxHealth;

                var orbitWalkerProvider = planetContext.OrbitWalkerProvider;
                orbitWalkerProvider.OrbitRadius = planetState.OrbitRadius;
                orbitWalkerProvider.StartAngle = planetState.CurAngle;
                orbitWalkerProvider.AngularSpeed = planetState.AngularSpeed;

                planetContext.transform.localRotation = Quaternion.Euler(planetState.Rotation);

                _planets.Add(planetContext);
            }

            var rndIndex = URandom.Range(0, _planets.Count);
            _playerPlanetId = _planets[rndIndex].Id;
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

        public void RemovePlanet(int id)
        {
            for(int i = 0; i < _planets.Count; i++)
            {
                if (id == _planets[i].Id)
                {
                    UObject.Destroy(_planets[i].gameObject);
                    break;
                }
            }

            if (id == _playerPlanetId)
                OnPlayerKilled?.Invoke();
            else if (_planets.Count == 1 && _planets[0].Id == _playerPlanetId)
                OnAllEnemiesKilled?.Invoke();
        }
    }
}