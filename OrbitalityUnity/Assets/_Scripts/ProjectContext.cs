using Windows;
using Game;

public class ProjectContext
{
    public static ProjectContext Instance = _instance ?? (_instance = new ProjectContext());

    private static ProjectContext _instance;

    public readonly WindowsController Windows;

    public GameLoader GameLoader { private set; get; }

    private ProjectContext()
    {
        Windows = new WindowsController();
    }

    public void CreateGameLoader(GameSettings gameSettings)
    {
        GameLoader = new GameLoader(gameSettings);
    }
}