using UnityEngine;

namespace Game.Damage
{
    public class HealthProvider : MonoBehaviour
    {
        [SerializeField] int _hp;

        public Health GetHealth()
        {
            return new Health(gameObject.GetInstanceID(), _hp);
        }
    }
}