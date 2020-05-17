using UnityEngine;

namespace Game.Fire
{
    using Damage;

    public class RocketProvider : MonoBehaviour
    {
        public RocketType RocketType;
        public DamageDealer RocketDamage;
        [SerializeField] Rigidbody _rb;
        [SerializeField] float _acceleration;

        public Rocket GetRocket()
        {
            return new Rocket {
                Rb = _rb,
                Acceleration = _acceleration
            };
        }
    }
}