using Windows;

public class ProjectContext
{
    public static ProjectContext Instance = _instance ?? (_instance = new ProjectContext());

    private static ProjectContext _instance;

    public readonly WindowsController Windows;

    private ProjectContext()
    {
        Windows = new WindowsController();
    }
}