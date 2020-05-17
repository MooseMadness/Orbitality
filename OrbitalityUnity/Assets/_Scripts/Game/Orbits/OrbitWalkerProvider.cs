using UnityEngine;

namespace Game.Orbits
{
    public class OrbitWalkerProvider : MonoBehaviour
    {
        public float OrbitRadius;
        public float AngularSpeed;
        public float StartAngle;

        public OrbitWalker GetOrbitWalker()
        {
            return new OrbitWalker {
                Id = gameObject.GetInstanceID(),
                Transform = transform,
                CurAngle = StartAngle,
                OrbitRadius = OrbitRadius,
                AngularSpeed = AngularSpeed,
            };
        }
    }
}