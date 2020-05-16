using UnityEngine;
using System.Collections.Generic;

namespace Game.Gravity
{
    public class GravitySystem
    {
        private List<Rigidbody> _gravityProducers;
        private GravitySettings _gravitySettings;

        public GravitySystem(GravitySettings gravitySettings)
        {
            _gravitySettings = gravitySettings;
            _gravityProducers = new List<Rigidbody>();
        }

        public void Add(Rigidbody gravityProducer)
        {
            _gravityProducers.Add(gravityProducer);
        }

        public void Add(IEnumerable<Rigidbody> gravityProducers)
        {
            _gravityProducers.AddRange(gravityProducers);
        }

        public void Remove(Rigidbody gravityProducer)
        {
            _gravityProducers.Remove(gravityProducer);
        }

        public Vector3 GetGravityForce(Rigidbody rigidbody)
        {
            var gravityForce = Vector3.zero;
            foreach (var gravityProducer in _gravityProducers)
                gravityForce += GetGravityForce(gravityProducer, rigidbody);
            return gravityForce;
        }

        private Vector3 GetGravityForce(Rigidbody gravityProducer, Rigidbody rigidBody)
        {
            var forceV = gravityProducer.position - rigidBody.position;
            var forceDir = forceV.normalized;
            var forceMagnitude = gravityProducer.mass * rigidBody.mass / forceV.sqrMagnitude;
            return forceDir * forceMagnitude * _gravitySettings.GravitationalConstant;
        }
    }
}