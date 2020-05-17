using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class PauseWindow : Window
    {
        [SerializeField] Button _continueBtn;
        [SerializeField] Button _exitBtn;

        public override WindowType WindowType => WindowType.Pause;

        protected override void Awake()
        {
            base.Awake();

            _continueBtn.onClick.AddListener(Continue);
            _exitBtn.onClick.AddListener(Exit);
        }

        public override void Show()
        {
            Time.timeScale = 0;
            base.Show();
        }

        private void Exit()
        {
            ProjectContext.Instance.GameLoader.ToMainMenu();
            Time.timeScale = 1;
        }

        private void Continue()
        {
            Time.timeScale = 1;
            Hide();
        }
    }
}