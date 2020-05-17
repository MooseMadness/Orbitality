using System;
using URandom = UnityEngine.Random;

namespace Utils
{
    [Serializable]
    public struct IntRange
    {
        public int From;
        public int To;

        public int Collapse()
        {
            return URandom.Range(From, To + 1);
        }
    }
}