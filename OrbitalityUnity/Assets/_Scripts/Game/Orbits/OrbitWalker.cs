using UnityEngine;

namespace Game.Orbits
{
    public class OrbitWalker
    {
        public int Id;
        public Transform Transform;
        /// <summary>
        /// speed in degress
        /// </summary>
        public float AngularSpeed;
        public float CurAngle;
        public float OrbitRadius;
    }
}