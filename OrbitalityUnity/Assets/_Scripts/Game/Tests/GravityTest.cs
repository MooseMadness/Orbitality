using UnityEngine;

namespace Game.Tests
{
    using Gravity;
    using Utils;

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
            _testRocket.UpdateVelocity(gravityF, Time.fixedDeltaTime);
        }
    }
}