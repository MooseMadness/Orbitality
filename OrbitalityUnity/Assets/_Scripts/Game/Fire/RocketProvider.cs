using UnityEngine;

namespace Game.Fire
{
    using Damage;
    using Utils;

    public class RocketProvider : MonoBehaviour
    {
        public RocketType RocketType;
        public DamageDealer RocketDamage;
        public LookToTransform ViewLook;
        [SerializeField] Rigidbody _rb;
        [SerializeField] float _acceleration;
        [SerializeField] float _startVelocity;

        public Rocket GetRocket()
        {
            var rocket = new Rocket {
                Rb = _rb,
                Acceleration = _acceleration
            };

            rocket.Rb.velocity = transform.forward * _startVelocity;

            return rocket;
        }
    }
}