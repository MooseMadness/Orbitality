using UnityEngine.SceneManagement;
using Utils;

namespace Game
{
    using States;
    using Saves;

    public class GameLoader
    {
        private const int MAIN_MENU_SCENE_INDEX = 0;
        private const int GAME_SCENE_INDEX = 1;

        public int MinPlanetsCount => 2;
        public int MaxPlanetsCount => _gameSettings.AvailablePlanetsCount;
        public GameState GameState { private set; get; }

        private readonly GameSettings _gameSettings;
        private readonly GameSave _gameSave;

        public GameLoader(GameSettings gameSettings, GameSave gameSave)
        {
            _gameSettings = gameSettings;
            _gameSave = gameSave;
        }

        public void NewGame(int planetsCount)
        {
            GenerateNewGameState(planetsCount);
            if(_gameSave.IsSaveExist())
                _gameSave.Clear();

            SceneManager.LoadScene(GAME_SCENE_INDEX, LoadSceneMode.Single);
        }

        public void Continue()
        {
            GameState = _gameSave.LoadSave();
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
                planet.RocketType = _gameSettings.AvailableRockets.GetRandom();

                GameState.Planets[i] = planet;

                orbitRadius += _gameSettings.OrbitStep;
            }
        }

        public void ToMainMenu(bool clearSave)
        {
            _gameSave.ClearGameEntities();
            if (clearSave && _gameSave.IsSaveExist())
                _gameSave.Clear();

            SceneManager.LoadScene(MAIN_MENU_SCENE_INDEX, LoadSceneMode.Single);
        }
    }
}