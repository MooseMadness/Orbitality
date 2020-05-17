using UnityEngine.UI;

namespace Game.Controlls
{
    using Contexts;
    using Fire;

    public class PlayerController
    {
        private Cannon _cannon;
        private Button _fireBtn;

        public PlayerController(PlanetContext planet, Button fireBtn)
        {
            _fireBtn = fireBtn;
            _cannon = planet.CannonProvider.GetCannon();
            fireBtn.onClick.AddListener(Fire);
        }

        public void Clear()
        {
            _fireBtn.onClick.RemoveListener(Fire);
            _cannon = null;
            _fireBtn = null;
        }

        private void Fire()
        {
            _cannon?.TryFire();
        }
    }
}