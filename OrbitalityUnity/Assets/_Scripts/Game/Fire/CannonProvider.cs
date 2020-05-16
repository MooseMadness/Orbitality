using UnityEngine;

namespace Game.Fire
{
    public class CannonProvider : MonoBehaviour
    {
        [SerializeField] RocketType _rocketType;
        [SerializeField] float _reloadingTime;

        public Cannon GetCannon(RocketsFactory rocketsFactory)
        {
            return new Cannon (
                transform,
                _reloadingTime,
                _rocketType,
                rocketsFactory
            );
        }
    }
}