using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class StartGameWindow : UpdateableWindow
    {
        [SerializeField] InputField _planetsCountIF;
        [SerializeField] Button _startBtn;

        public override WindowType WindowType => WindowType.StartGame;

        private int _minPlanetsCount;
        private int _maxPlanetsCount;

        protected override void Awake()
        {
            base.Awake();

            _startBtn.onClick.AddListener(StartGame);
            _planetsCountIF.onValueChanged.AddListener(ValidatePlanetsCount);
        }

        protected override void UpdateData()
        {
            _startBtn.interactable = false;

            var gameLoader = ProjectContext.Instance.GameLoader;
            _minPlanetsCount = gameLoader.MinPlanetsCount;
            _maxPlanetsCount = gameLoader.MaxPlanetsCount;
        }

        private void ValidatePlanetsCount(string value)
        {
            if (string.IsNullOrEmpty(value))
                _startBtn.interactable = false;

            var planetsCount = int.Parse(value);
            if (planetsCount > _maxPlanetsCount)
            {
                planetsCount = _maxPlanetsCount;
                _planetsCountIF.text = _maxPlanetsCount.ToString();
            }
            else if (planetsCount < _minPlanetsCount)
            {
                planetsCount = _minPlanetsCount;
                _planetsCountIF.text = _minPlanetsCount.ToString();
            }

            _startBtn.interactable = true;
        }

        private void StartGame()
        {
            var planetsCount = int.Parse(_planetsCountIF.text);
            ProjectContext.Instance.GameLoader.NewGame(planetsCount);
        }
    }
}