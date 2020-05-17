using UnityEngine;

namespace Game.Damage
{
    public class HealthProvider : MonoBehaviour
    {
        public int StartHp;
        public int MaxHp;
        [SerializeField] HealthView _healthView;

        private Health _health;

        public void SetColor(Color color)
        {
            _healthView.SetColor(color);
        }

        public Health GetHealth()
        {
            if (_health == null)
            {
                _health = new Health(gameObject.GetInstanceID(), StartHp, MaxHp);
                _healthView.UpdateHealth(StartHp, MaxHp);
                _health.OnDamage += _healthView.UpdateHealth;
            }

            return _health;
        }
    }
}