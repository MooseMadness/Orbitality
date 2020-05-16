using UnityEngine.UI;

namespace Game.Controlls
{
    using Contexts;
    using Fire;

    public class PlayerController
    {
        private Cannon _cannon;

        public PlayerController(PlanetContext planet, Button fireBtn)
        {
            _cannon = planet.CannonProvider.GetCannon();
            fireBtn.onClick.AddListener(Fire);
        }

        private void Fire()
        {
            _cannon.TryFire();
        }
    }
}