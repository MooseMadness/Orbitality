using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public abstract class ResultWindow : Window
    {
        [SerializeField] Button _mainMenuBtn;

        protected override void Awake()
        {
            base.Awake();

            _mainMenuBtn.onClick.AddListener(ToMainMenu);
        }

        private void ToMainMenu()
        {
            var projectContext = ProjectContext.Instance;
            projectContext.GameLoader.ToMainMenu(true);
        }
    }
}