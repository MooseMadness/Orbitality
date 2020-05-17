using System.Collections.Generic;

namespace Game.Damage
{
    public class HealthsContainer
    {
        public event OnKilledHandler OnKilled;

        private SortedDictionary<int, Health> _healths;

        public HealthsContainer()
        {
            _healths = new SortedDictionary<int, Health>();
        }

        public void AddHealth(Health health)
        {
            _healths.Add(health.Id, health);
            health.OnKilled += RemoveHealth;
        }

        private void RemoveHealth(int id)
        {
            if (_healths.Remove(id))
                OnKilled?.Invoke(id);
        }

        public Health GetHealth(int id)
        {
            _healths.TryGetValue(id, out Health health);
            return health;
        }
    }
}