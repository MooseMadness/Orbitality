using System;
using Utils;

namespace Game.States
{
    using Fire;

    [Serializable]
    public class PlanetState
    {
        public int MaxHealth;
        public int CurHealth;
        public float OrbitRadius;
        public float AngularSpeed;
        public float CurAngle;
        public Vector3Wraper Rotation;
        public RocketType RocketType;
        public bool IsPlayer;
    }
}