using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class OpenWindowBtn : MonoBehaviour
    {
        [SerializeField] Button _pauseBtn;
        [SerializeField] WindowType _window;

        private void Awake()
        {
            _pauseBtn.onClick.AddListener(Open);
        }

        private void Open()
        {
            ProjectContext.Instance.Windows.Show(_window);
        }
    }
}