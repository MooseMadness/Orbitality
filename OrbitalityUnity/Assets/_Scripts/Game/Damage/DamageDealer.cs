using UnityEngine;
using System;

namespace Game.Damage
{
    using Utils;

    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] int _damageAmount;
        [SerializeField] LayerMask _damageLayer;

        public event OnDealDamageHandler OnDealDamage;

        private HealthsContainer _healthsContainer;

        public void SetHealthsContainer(HealthsContainer healthsContainer)
        {
            _healthsContainer = healthsContainer;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_healthsContainer == null)
                return;

            var collidingGO = other.gameObject;
            if (!_damageLayer.Contains(collidingGO.layer))
                return;
            
            var healthId = collidingGO.GetInstanceID();
            var health = _healthsContainer.GetHealth(healthId);
            if (health != null)
                health.TakeDamage(_damageAmount);

            var myId = gameObject.GetInstanceID();
            OnDealDamage?.Invoke(this);
        }

        private void OnDestroy()
        {
            OnDealDamage = null;
        }
    }
}