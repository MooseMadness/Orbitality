using UnityEngine.SceneManagement;

namespace Game
{
    using States;

    public class GameLoader
    {
        private const int MAIN_MENU_SCENE_INDEX = 0;
        private const int GAME_SCENE_INDEX = 1;

        public int MinPlanetsCount => 2;
        public int MaxPlanetsCount => _gameSettings.AvailablePlanetsIds.Length;
        public GameState GameState { private set; get; }

        private GameSettings _gameSettings;

        public GameLoader(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public void NewGame(int planetsCount)
        {
            GenerateNewGameState(planetsCount);
            SceneManager.LoadScene(GAME_SCENE_INDEX, LoadSceneMode.Single);
        }

        private void GenerateNewGameState(int planetsCount)
        {
            GameState = new GameState();
            GameState.Planets = new PlanetState[planetsCount];

            var orbitRadius = _gameSettings.FirstOrbitRadius;
            for (int i = 0; i < planetsCount; i++)
            {
                var planet = new PlanetState();
                planet.CurHealth = planet.MaxHealth = _gameSettings.PlanetHealts.Collapse();
                planet.AngularSpeed = _gameSettings.AngleSpeeds.Collapse();
                planet.CurAngle = _gameSettings.StartAngles.Collapse();
                planet.OrbitRadius = orbitRadius;

                GameState.Planets[i] = planet;

                orbitRadius += _gameSettings.OrbitStep;
            }
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene(MAIN_MENU_SCENE_INDEX, LoadSceneMode.Single);
        }
    }
}