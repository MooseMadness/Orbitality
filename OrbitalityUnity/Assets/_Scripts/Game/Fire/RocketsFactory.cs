using UnityEngine;

namespace Game.Fire
{
    public class RocketsFactory
    {
        [SerializeField] RocketsStorage _storage;
        [SerializeField] RocketsMovementSystem _movementSystem;
        [SerializeField] Transform _rocketsParent;

        public RocketsFactory(
            RocketsStorage rocketsStorage, 
            RocketsMovementSystem movementSystem, 
            Transform rocketsParent
        )
        {
            _storage = rocketsStorage;
            _movementSystem = movementSystem;
            _rocketsParent = rocketsParent;
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
            _movementSystem.AddRocket(rocketProvider.GetRocket());
        }
    }
}