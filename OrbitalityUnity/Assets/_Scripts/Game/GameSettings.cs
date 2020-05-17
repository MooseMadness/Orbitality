using UnityEngine;
using Utils;

namespace Game
{
    using Fire;

    [CreateAssetMenu(fileName = "GameSettings", menuName = "Configs/Game/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public float OrbitStep;
        public float FirstOrbitRadius;
        public Range AngleSpeeds;
        public Range StartAngles;
        public RocketType[] AvailableRockets;
        public IntRange PlanetHealts;
        public int AvailablePlanetsCount;
    }
}