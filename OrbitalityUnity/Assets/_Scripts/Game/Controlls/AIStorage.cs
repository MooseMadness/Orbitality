using System.Collections.Generic;
using Utils;

namespace Game.Controlls
{
    using Contexts;
    using GameLoop;

    public class AIStorage
    {
        private SortedDictionary<int, AIController> _ais;
        private SystemsUpdater _systemsUpdater;

        public AIStorage(
            IEnumerable<PlanetContext> planetsContext, 
            SystemsUpdater systemsUpdater, 
            Range fireInterval
        )
        {
            _systemsUpdater = systemsUpdater;
            _ais = new SortedDictionary<int, AIController>();

            foreach(var planet in planetsContext)
            {
                var cannon = planet.CannonProvider.GetCannon();
                var ai = new AIController(cannon, fireInterval);
                _systemsUpdater.AddFrameTicker(ai);
                _ais.Add(planet.Id, ai);
            }
        }

        private void DisableAI(int id)
        {
            _ais.TryGetValue(id, out AIController ai);
            _systemsUpdater.RemoveFrameTicker(ai);
            _ais.Remove(id);
        }
    }
}