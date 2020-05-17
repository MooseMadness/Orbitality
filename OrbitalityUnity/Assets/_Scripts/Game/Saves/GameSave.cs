using Saves;

namespace Game.Saves
{
    using States;
    using Fire;
    using Planets;

    public class GameSave
    {
        private const string SAVE_NAME = "Save0.dat";

        private readonly SavesController _savesController;

        private PlanetsStorage _planetsStorage;
        private RocketsMovementSystem _rocketsMovementSystem;

        public GameSave(SavesController savesController)
        {
            _savesController = savesController;
        }

        public void SetGameEntities(PlanetsStorage planetsStorage, RocketsMovementSystem movementSystem)
        {
            _planetsStorage = planetsStorage;
            _rocketsMovementSystem = movementSystem;
        }

        public void ClearGameEntities()
        {
            _planetsStorage = null;
            _rocketsMovementSystem = null;
        }

        public void CreateSave()
        {
            var gameState = new GameState {
                Planets = _planetsStorage.GetPlanetsStates(),
                Rockets = _rocketsMovementSystem.GetRocketsStates()
            };
            _savesController.SaveData(SAVE_NAME, gameState);
        }

        public bool IsSaveExist()
        {
            return _savesController.IsDataExist(SAVE_NAME);
        }

        public GameState LoadSave()
        {
            return _savesController.LoadData<GameState>(SAVE_NAME);
        }

        public void Clear()
        {
            _savesController.RemoveData(SAVE_NAME);
        }
    }
}