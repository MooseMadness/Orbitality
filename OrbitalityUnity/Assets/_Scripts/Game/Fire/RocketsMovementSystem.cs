using System.Collections.Generic;
using UnityEngine;

namespace Game.Fire
{
    using Gravity;
    using Utils;
    using GameLoop;
    using States;

    public class RocketsMovementSystem : ITickable
    {
        private GravitySystem _gravitySystem;
        private SortedList<int, Rocket> _rockets;

        public RocketsMovementSystem(GravitySystem gravitySystem)
        {
            _gravitySystem = gravitySystem;
            _rockets = new SortedList<int, Rocket>();
        }

        public RocketState[] GetRocketsStates()
        {
            var states = new RocketState[_rockets.Values.Count];
            for(int i = 0; i < states.Length; i++)
            {
                var rocket = _rockets.Values[i];
                var state = new RocketState();

                state.CurVelocity = rocket.Rb.velocity;
                state.RocketType = rocket.RocketType;
                state.Rotation = rocket.Rb.transform.rotation.eulerAngles;
                state.WorldCoords = rocket.Rb.transform.position;

                states[i] = state;
            }

            return states;
        }

        public void Add(int rocketId, Rocket rocket)
        {
            _rockets.Add(rocketId, rocket);
        }

        public void Remove(int rocketId)
        {
            _rockets.Remove(rocketId);
        }

        public void Tick(float deltaTime)
        {
            foreach (var rocket in _rockets.Values)
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