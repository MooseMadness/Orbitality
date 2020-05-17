namespace Game.Damage
{
    public class Health
    {
        public readonly int Id;

        public readonly int MaxHp;

        public int CurHp { private set; get; }

        public event OnDamageHandler OnDamage;
        public event OnKilledHandler OnKilled;

        public Health(int id, int healthAmount, int maxHealth)
        {
            Id = id;
            CurHp = healthAmount;
            MaxHp = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            CurHp -= amount;
            if (CurHp < 0)
                CurHp = 0;

            OnDamage?.Invoke(CurHp, MaxHp);

            if(CurHp == 0)
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