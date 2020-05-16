using UnityEngine.UI;

namespace Game.Controlls
{
    public class PlayerController
    {
        private PlanetContext _planetContext;

        public PlayerController(PlanetContext planet, Button fireBtn)
        {
            _planetContext = planet;
            fireBtn.onClick.AddListener(Fire);
        }

        private void Fire()
        {
            _planetContext.Cannon.TryFire();
        }
    }
}