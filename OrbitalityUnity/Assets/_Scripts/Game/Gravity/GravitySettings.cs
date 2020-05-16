using UnityEngine;

namespace Game.Gravity
{
    [CreateAssetMenu(fileName = "GravitySettings", menuName = "Configs/Game/GravitySettings")]
    public class GravitySettings : ScriptableObject
    {
        [Tooltip("How strong presence of gravitaion")]
        public float GravitationalConstant;
    }
}