using UnityEngine.UI;

namespace Game.Controlls
{
    using Fire;

    public class PlayerController
    {
        private Cannon _cannon;
        private Button _fireBtn;

        public PlayerController(Cannon cannon, Button fireBtn)
        {
            _fireBtn = fireBtn;
            _cannon = cannon;
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