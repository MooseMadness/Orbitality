using UnityEngine;

namespace Game.Fire
{
    public class CannonProvider : MonoBehaviour
    {
        [SerializeField] RocketType _rocketType;
        [SerializeField] float _reloadingTime;

        private Cannon _cannon;
        private RocketsFactory _rocketsFactory;

        public void SetFactory(RocketsFactory rocketsFactory)
        {
            _rocketsFactory = rocketsFactory;
        }

        public Cannon GetCannon()
        {
            if (_cannon == null)
            {
                _cannon = new Cannon(
                      transform,
                      _reloadingTime,
                      _rocketType,
                      _rocketsFactory
                  );
            }

            return _cannon;
        }
    }
}