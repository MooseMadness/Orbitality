using UnityEngine;

namespace Game.Utils
{
    public static class PhysicsExtensions
    {
        /// <summary>
        /// Update rigidbody velocity according to applyed force
        /// </summary>
        public static void UpdateVelocity(this Rigidbody rb, Vector3 force, float deltaTime)
        {
            var accelerationV = force / rb.mass;
            rb.velocity += accelerationV * deltaTime;
        }
    }
}