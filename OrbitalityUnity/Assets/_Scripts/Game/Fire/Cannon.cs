using UnityEngine;

namespace Game.Fire
{
    using GameLoop;

    public class Cannon : ITickable
    {
        public readonly RocketType RocketType;

        public event OnTimerChangedHandler OnTimerChanged;

        private Transform _transform;
        private float _reloadingTime;
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
            RocketType = rocketType;
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

            _rocketsFactory.CreateRocket(RocketType, _transform.position, _transform.forward);
            _counter = _reloadingTime;
            OnTimerChanged?.Invoke(_counter);
            return true;
        }

        public void Tick(float deltaTime)
        {
            if (_counter > 0)
            {
                _counter -= deltaTime;
                OnTimerChanged?.Invoke(_counter);
            }
        }
    }
}