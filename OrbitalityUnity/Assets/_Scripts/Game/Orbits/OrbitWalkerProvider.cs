using UnityEngine;

namespace Game.Orbits
{
    public class OrbitWalkerProvider : MonoBehaviour
    {
        public float OrbitRadius;
        public float AngularSpeed;
        public float StartAngle;

        private OrbitWalker _orbitWalker;

        public OrbitWalker GetOrbitWalker()
        {
            if (_orbitWalker == null)
            {
                _orbitWalker = new OrbitWalker {
                    Id = gameObject.GetInstanceID(),
                    Transform = transform,
                    CurAngle = StartAngle,
                    OrbitRadius = OrbitRadius,
                    AngularSpeed = AngularSpeed,
                };
            }

            return _orbitWalker;
        }
    }
}