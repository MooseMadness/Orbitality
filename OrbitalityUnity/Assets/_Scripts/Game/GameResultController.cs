using Windows;

namespace Game
{
    public class GameResultController
    {
        private bool _isHaveResult;

        public void Win()
        {
            if (_isHaveResult)
                return;

            _isHaveResult = true;
            ProjectContext.Instance.Windows.Show(WindowType.Win);
        }

        public void Loose()
        {
            if (_isHaveResult)
                return;

            _isHaveResult = true;
            ProjectContext.Instance.Windows.Show(WindowType.Loose);
        }
    }
}