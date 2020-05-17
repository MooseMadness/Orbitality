using UnityEngine;

namespace Game.Damage
{
    public class HealthProvider : MonoBehaviour
    {
        public int StartHp;
        public int MaxHp;
        [SerializeField] HealthView _healthView;

        public void SetColor(Color color)
        {
            _healthView.SetColor(color);
        }

        public Health GetHealth()
        {
            var health = new Health(gameObject.GetInstanceID(), StartHp, MaxHp);
            _healthView.UpdateHealth(StartHp, MaxHp);
            health.OnDamage += _healthView.UpdateHealth;
            return health;
        }
    }
}