using UnityEngine;

namespace Game.Tests
{
    using Gravity;

    public class GravityTest : MonoBehaviour
    {
        [SerializeField] Rigidbody _testRocket;
        [SerializeField] Vector3 _rocketStartVelocity;
        [SerializeField] Rigidbody[] _testPlanets;
        [SerializeField] GravitySettings _gravitySettings;

        private GravitySystem _gravitySystem;

        private void Start()
        {
            _gravitySystem = new GravitySystem(_gravitySettings);
            _gravitySystem.Add(_testPlanets);
            _testRocket.velocity = _rocketStartVelocity;
        }

        private void FixedUpdate()
        {
            var gravityF = _gravitySystem.GetGravityForce(_testRocket);
            var acceleration = GetAcceleration(_testRocket.mass, gravityF);
            _testRocket.velocity += acceleration * Time.fixedDeltaTime;
        }

        private Vector3 GetAcceleration(float mass, Vector3 force)
        {
            return force / mass;
        }
    }
}