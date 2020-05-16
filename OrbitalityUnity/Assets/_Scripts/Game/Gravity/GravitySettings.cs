using UnityEngine;

namespace Game.Gravity
{
    [CreateAssetMenu(fileName = "GravitySettings", menuName = "Configs/Game/GravitySettings")]
    public class GravitySettings : ScriptableObject
    {
        public float GravitationalConstant;
    }
}