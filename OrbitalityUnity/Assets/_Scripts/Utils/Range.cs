using System;
using URandom = UnityEngine.Random;

namespace Utils
{
    [Serializable]
    public struct Range
    {
        public float From;
        public float To;

        public float Collapse()
        {
            return URandom.Range(From, To);
        }
    }
}