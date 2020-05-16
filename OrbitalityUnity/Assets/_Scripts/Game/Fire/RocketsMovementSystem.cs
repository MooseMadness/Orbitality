using System.Collections.Generic;
using UnityEngine;

namespace Game.Fire
{
    using Gravity;
    using Utils;
    using GameLoop;

    public class RocketsMovementSystem : ITickable
    {
        private GravitySystem _gravitySystem;
        private List<Rocket> _rockets;

        public RocketsMovementSystem(GravitySystem gravitySystem)
        {
            _gravitySystem = gravitySystem;
            _rockets = new List<Rocket>();
        }

        public void AddRocket(Rocket rocket)
        {
            _rockets.Add(rocket);
        }

        public void Tick(float deltaTime)
        {
            foreach (var rocket in _rockets)
            {
                ApplyForces(rocket, deltaTime);
                CorrectRotationToVelocity(rocket);
            }
        }

        private void ApplyForces(Rocket rocket, float deltaTime)
        {
            var gravityForce = _gravitySystem.GetGravityForce(rocket.Rb);
            var flyDir = rocket.Rb.transform.forward;
            var accelerationForce = flyDir * rocket.Acceleration * rocket.Rb.mass;
            var resultForce = accelerationForce + gravityForce;
            rocket.Rb.UpdateVelocity(resultForce, deltaTime);
        }

        private void CorrectRotationToVelocity(Rocket rocket)
        {
            if (Mathf.Approximately(rocket.Rb.velocity.magnitude, 0))
                return;
            
            rocket.Rb.transform.rotation = Quaternion.LookRotation(rocket.Rb.velocity.normalized);
        }
    }
}