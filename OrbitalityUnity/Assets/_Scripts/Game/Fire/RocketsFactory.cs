using UnityEngine;

namespace Game.Fire
{
    using Damage;
    using States;

    public class RocketsFactory
    {
        private RocketsStorage _storage;
        private RocketsMovementSystem _movementSystem;
        private Transform _rocketsParent;
        private HealthsContainer _healthsContainer;
        private Transform _cameraTransform;

        public RocketsFactory(
            RocketsStorage rocketsStorage,
            RocketsMovementSystem movementSystem,
            Transform rocketsParent,
            HealthsContainer healthsContainer,
            Transform cameraTransform
        )
        {
            _storage = rocketsStorage;
            _movementSystem = movementSystem;
            _rocketsParent = rocketsParent;
            _healthsContainer = healthsContainer;
            _cameraTransform = cameraTransform;
        }

        public void CreateRockets(RocketState[] rocketsStates)
        {
            if (rocketsStates == null)
                return;

            foreach(var state in rocketsStates)
            {
                var rocket = CreateRocket(state.RocketType, state.WorldCoords, Vector3.one);
                rocket.Rb.transform.rotation = Quaternion.Euler(state.Rotation);
                rocket.Rb.velocity = state.CurVelocity;
            }
        }

        public Rocket CreateRocket(RocketType type, Vector3 startPos, Vector3 startDir)
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
            var rocket = rocketProvider.GetRocket();
            _movementSystem.Add(rocketId, rocket);
            rocketDamage.OnDealDamage += RemoveRocket;
            rocketDamage.SetHealthsContainer(_healthsContainer);
            rocketProvider.ViewLook.TransformToLook = _cameraTransform;

            return rocket;
        }

        private void RemoveRocket(DamageDealer rocket)
        {
            var id = rocket.gameObject.GetInstanceID();
            _movementSystem.Remove(id);
            Object.Destroy(rocket.gameObject);
        }
    }
}