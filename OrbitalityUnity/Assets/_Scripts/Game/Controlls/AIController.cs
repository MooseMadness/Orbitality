using Utils;

namespace Game.Controlls
{
    using Fire;
    using GameLoop;

    public class AIController : ITickable
    {
        private Cannon _cannon;
        private Range _fireInterval;

        private float _counter;

        public AIController(Cannon cannon, Range fireInterval)
        {
            _cannon = cannon;
            _fireInterval = fireInterval;
            _counter = fireInterval.Collapse();
        }

        void ITickable.Tick(float deltaTime)
        {
            if (!_cannon.IsValid() || !_cannon.IsReloaded)
                return;

            if(_counter <= 0)
            {
                _counter = _fireInterval.Collapse();
                _cannon.TryFire();
            }
            else
            {
                _counter -= deltaTime;
            }
        }
    }
}