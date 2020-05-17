using URandom = UnityEngine.Random;

namespace Utils
{
    public static class CollectionsExtensions
    {
        public static T GetRandom<T>(this T[] arr)
        {
            return arr[URandom.Range(0, arr.Length)];
        }
    }
}