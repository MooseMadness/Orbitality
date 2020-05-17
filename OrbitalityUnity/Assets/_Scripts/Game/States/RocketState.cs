using UnityEngine;
using System;

namespace Game.States
{
    using Fire;

    [Serializable]
    public class RocketState
    {
        public RocketType RocketType;
        public Vector3 CurVelocity;
        public Vector3 WorldCoords;
        public Vector3 Rotation;
    }
}