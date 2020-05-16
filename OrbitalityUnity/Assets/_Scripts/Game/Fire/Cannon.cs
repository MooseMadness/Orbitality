using UnityEngine;

namespace Game.Fire
{
    using GameLoop;

    public class Cannon : ITickable
    {
        private Transform _transform;
        private float _reloadingTime;
        private RocketType _rocketType;
        private float _counter;
        private RocketsFactory _rocketsFactory;

        public bool IsReloaded => _counter <= 0;

        public Cannon(
            Transform transform, 
            float reloadingTime, 
            RocketType rocketType, 
            RocketsFactory rocketsFactory
        )
        {
            _transform = transform;
            _reloadingTime = reloadingTime;
            _rocketType = rocketType;
            _rocketsFactory = rocketsFactory;
        }

        /// <returns>Was attempt of fire successfull</returns>
        public bool TryFire()
        {
            if (!IsReloaded)
                return false;

            _rocketsFactory.CreateRocket(_rocketType, _transform.position, _transform.forward);
            _counter = _reloadingTime;
            return true;
        }

        public void Tick(float deltaTime)
        {
            if(_counter > 0)
                _counter -= deltaTime;
        }
    }
}