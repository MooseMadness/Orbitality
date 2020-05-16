using UnityEngine;

namespace Game.Orbits
{
    public class OrbitWalkerProvider : MonoBehaviour
    {
        [SerializeField] float _orbitRadius;
        [SerializeField] float _angularSpeed;
        [SerializeField] float _startAngle;

        public OrbitWalker GetOrbitWalker()
        {
            return new OrbitWalker {
                Id = gameObject.GetInstanceID(),
                Transform = transform,
                CurAngle = _startAngle,
                OrbitRadius = _orbitRadius,
                AngularSpeed = _angularSpeed,
            };
        }
    }
}