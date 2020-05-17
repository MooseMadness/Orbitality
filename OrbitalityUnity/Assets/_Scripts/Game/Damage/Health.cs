namespace Game.Damage
{
    public class Health
    {
        public readonly int Id;

        private readonly int _maxHp;
        private int _curHp;

        public event OnDamageHandler OnDamage;
        public event OnKilledHandler OnKilled;

        public Health(int id, int healthAmount, int maxHealth)
        {
            Id = id;
            _curHp = healthAmount;
            _maxHp = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            _curHp -= amount;
            if (_curHp < 0)
                _curHp = 0;

            OnDamage?.Invoke(_curHp);

            if(_curHp == 0)
                OnKilled?.Invoke(Id);
        }

        private void Kill()
        {
            OnKilled?.Invoke(Id);

            OnKilled = null;
            OnDamage = null;
        }
    }
}