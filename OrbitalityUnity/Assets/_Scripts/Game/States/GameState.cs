using System;

namespace Game.States
{
    [Serializable]
    public class GameState
    {
        public PlanetState[] Planets;
        public RocketState[] Rockets;
    }
}