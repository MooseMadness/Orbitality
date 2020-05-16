using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLoop
{
    public class SystemsUpdater : MonoBehaviour
    {
        private List<ITickable> _frameTickers;
        private List<ITickable> _physicsTickers;

        private void Awake()
        {
            _frameTickers = new List<ITickable>();
            _physicsTickers = new List<ITickable>();
        }

        public void AddFrameTicker(ITickable ticker)
        {
            _frameTickers.Add(ticker);
        }

        public void AddPhysicsTicker(ITickable ticker)
        {
            _physicsTickers.Add(ticker);
        }

        private void Update()
        {
            if (_frameTickers == null)
                return;

            var deltaTime = Time.deltaTime;
            foreach (var frameTicker in _frameTickers)
                frameTicker.Tick(deltaTime);
        }

        private void FixedUpdate()
        {
            if (_physicsTickers == null)
                return;

            var fixedDeltaTime = Time.fixedDeltaTime;
            foreach (var physicsTicker in _physicsTickers)
                physicsTicker.Tick(fixedDeltaTime);
        }
    }
}