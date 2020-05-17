using UnityEngine;

namespace Game.Damage
{
    public class HealthProvider : MonoBehaviour
    {
        public int StartHp;
        public int MaxHp;

        public Health GetHealth()
        {
            return new Health(gameObject.GetInstanceID(), StartHp, MaxHp);
        }
    }
}