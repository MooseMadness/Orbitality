using System;
using Utils;

namespace Game.States
{
    using Fire;

    [Serializable]
    public class RocketState
    {
        public RocketType RocketType;
        public Vector3Wraper CurVelocity;
        public Vector3Wraper WorldCoords;
        public Vector3Wraper Rotation;
    }
}