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

        /// <summary>
        /// check is cannon transform still alive 
        /// </summary>
        public bool IsValid()
        {
            return _transform;
        }

        /// <returns>Is attempt of fire successfull</returns>
        public bool TryFire()
        {
            if (!IsReloaded)
                return false;

            try
            {
                _rocketsFactory.CreateRocket(_rocketType, _transform.position, _transform.forward);
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
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