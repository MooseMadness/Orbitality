using UnityEngine;
using Game;
using Windows;

public class AppStartup : MonoBehaviour
{
    [SerializeField] GameSettings _gameSettings;

    private void Awake()
    {
        ProjectContext.Instance.CreateGameLoader(_gameSettings);
    }

    private void Start()
    {
        ProjectContext.Instance.Windows.Show(WindowType.MainMenu);
    }
}