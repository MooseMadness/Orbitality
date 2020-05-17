using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class MainMenuWindow : Window
    {
        [SerializeField] Button _continueBtn;
        [SerializeField] Button _newGameBtn;
        [SerializeField] Button _exitBtn;

        public override WindowType WindowType => WindowType.MainMenu;

        protected override void Awake()
        {
            base.Awake();

            _continueBtn.onClick.AddListener(Continue);
            _newGameBtn.onClick.AddListener(NewGame);
            _exitBtn.onClick.AddListener(Exit);
        }

        public override void Show()
        {
            var gameSave = ProjectContext.Instance.GameSave;
            _continueBtn.interactable = gameSave.IsSaveExist();
            base.Show();
        }

        private void Continue()
        {
            ProjectContext.Instance.GameLoader.Continue();
        }

        private void NewGame()
        {
            Hide();
            ProjectContext.Instance.Windows.Show(WindowType.StartGame);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}