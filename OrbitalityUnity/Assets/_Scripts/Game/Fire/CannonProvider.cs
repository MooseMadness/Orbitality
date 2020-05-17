using UnityEngine;

namespace Game.Fire
{
    public class CannonProvider : MonoBehaviour
    {
        public RocketType RocketType;
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
                    RocketType,
                    _rocketsFactory
                );
            }

            return _cannon;
        }
    }
}