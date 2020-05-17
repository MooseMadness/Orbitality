using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public struct Vector3Wraper
    {
        public float X;
        public float Y;
        public float Z;

        public static implicit operator Vector3Wraper(Vector3 vector)
        {
            return new Vector3Wraper {
                X = vector.x,
                Y = vector.y,
                Z = vector.z
            };
        }

        public static implicit operator Vector3(Vector3Wraper vectorWraper)
        {
            return new Vector3(vectorWraper.X, vectorWraper.Y, vectorWraper.Z);
        }
    }
}