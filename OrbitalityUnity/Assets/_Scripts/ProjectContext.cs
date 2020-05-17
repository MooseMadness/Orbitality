using Windows;
using Saves;
using Game;
using Game.Saves;

public class ProjectContext
{
    public static ProjectContext Instance = _instance ?? (_instance = new ProjectContext());

    private static ProjectContext _instance;

    public readonly WindowsController Windows;
    public readonly GameSave GameSave;

    public GameLoader GameLoader { private set; get; }
    
    private ProjectContext()
    {
        Windows = new WindowsController();
        var saveController = new SavesController();
        GameSave = new GameSave(saveController);
    }

    public void CreateGameLoader(GameSettings gameSettings)
    {
        GameLoader = new GameLoader(gameSettings, GameSave);
    }
}