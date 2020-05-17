using UnityEngine;

namespace Game.Damage
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _bar;

        private float _startScale;

        private void Awake()
        {
            _startScale = _bar.transform.localScale.x;
        }

        public void UpdateHealth(int curHealth, int maxHealth)
        {
            var percent = curHealth / (float)maxHealth;
            var barScale = _bar.transform.localScale;
            barScale.x = _startScale * percent;
            _bar.transform.localScale = barScale;
        }

        public void SetColor(Color color)
        {
            _bar.color = color;
        }
    }
}