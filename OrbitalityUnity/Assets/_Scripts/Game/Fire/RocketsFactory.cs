using UnityEngine;

namespace Game.Fire
{
    using Damage;

    public class RocketsFactory
    {
        private RocketsStorage _storage;
        private RocketsMovementSystem _movementSystem;
        private Transform _rocketsParent;
        private HealthsContainer _healthsContainer;

        public RocketsFactory(
            RocketsStorage rocketsStorage, 
            RocketsMovementSystem movementSystem, 
            Transform rocketsParent,
            HealthsContainer healthsContainer
        )
        {
            _storage = rocketsStorage;
            _movementSystem = movementSystem;
            _rocketsParent = rocketsParent;
            _healthsContainer = healthsContainer;
        }

        public void CreateRocket(RocketType type, Vector3 startPos, Vector3 startDir)
        {
            var rocketPrefab = _storage.GetRocketPrefab(type);
            var rocketProvider = Object.Instantiate(
                rocketPrefab, 
                startPos, 
                Quaternion.LookRotation(startDir), 
                _rocketsParent
            );

            var rocketDamage = rocketProvider.RocketDamage;
            var rocketId = rocketDamage.gameObject.GetInstanceID();
            _movementSystem.Add(rocketId, rocketProvider.GetRocket());
            rocketDamage.OnDealDamage += RemoveRocket;
            rocketDamage.SetHealthsContainer(_healthsContainer);
        }

        private void RemoveRocket(DamageDealer rocket)
        {
            var id = rocket.gameObject.GetInstanceID();
            _movementSystem.Remove(id);
            Object.Destroy(rocket.gameObject);
        }
    }
}