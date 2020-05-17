using UnityEngine;
using System.Collections.Generic;

namespace Game.Gravity
{
    public class GravitySystem
    {
        private SortedList<int, Rigidbody> _gravityProducers;
        private GravitySettings _gravitySettings;

        public GravitySystem(GravitySettings gravitySettings)
        {
            _gravitySettings = gravitySettings;
            _gravityProducers = new SortedList<int, Rigidbody>();
        }

        public void Add(IEnumerable<Rigidbody> gravityProducers)
        {
            foreach (var gravityProducer in gravityProducers)
                Add(gravityProducer);
        }

        public void Add(Rigidbody gravityProducer)
        {
            var id = gravityProducer.gameObject.GetInstanceID();
            _gravityProducers.Add(id, gravityProducer);
        }

        public void Remove(int id)
        {
            _gravityProducers.Remove(id);
        }

        public Vector3 GetGravityForce(Rigidbody rigidbody)
        {
            var gravityForce = Vector3.zero;
            foreach (var gravityProducer in _gravityProducers.Values)
                gravityForce += GetGravityForce(gravityProducer, rigidbody);
            return gravityForce;
        }

        private Vector3 GetGravityForce(Rigidbody gravityProducer, Rigidbody rigidBody)
        {
            var forceV = gravityProducer.position - rigidBody.position;
            if (Mathf.Approximately(forceV.magnitude, 0))
                return Vector3.zero;

            var forceDir = forceV.normalized;
            var forceMagnitude = gravityProducer.mass * rigidBody.mass / forceV.magnitude;
            return forceDir * forceMagnitude * _gravitySettings.GravitationalConstant;
        }
    }
}