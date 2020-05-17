using System.Collections.Generic;

namespace Windows
{
    public class WindowsController
    {
        private SortedDictionary<WindowType, Window> _registeredWindows;

        public WindowsController()
        {
            _registeredWindows = new SortedDictionary<WindowType, Window>();
        }

        public void Register(Window window)
        {
            _registeredWindows.Add(window.WindowType, window);
        }

        public void UnRegister(Window window)
        {
            _registeredWindows.Remove(window.WindowType);
        }

        public void Show(WindowType windowType)
        {
            _registeredWindows.TryGetValue(windowType, out Window window);
            window?.Show();
        }

        public void Hide(WindowType windowType)
        {
            _registeredWindows.TryGetValue(windowType, out Window window);
            window?.Hide();
        }
    }
}