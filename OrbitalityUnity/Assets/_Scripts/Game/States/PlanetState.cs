using System;
using UnityEngine;

namespace Game.States
{
    [Serializable]
    public class PlanetState
    {
        public int PlanetTypeId;
        public int MaxHealth;
        public int CurHealth;
        public float OrbitRadius;
        public float AngularSpeed;
        public float CurAngle;
        public Vector3 Rotation;
    }
}