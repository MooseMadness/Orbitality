using UnityEngine;

namespace Windows
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] GameObject _root;

        public abstract WindowType WindowType { get; }

        protected virtual void Awake()
        {
            ProjectContext.Instance.Windows.Register(this);
        }

        private void OnDestroy()
        {
            ProjectContext.Instance.Windows.UnRegister(this);
        }

        public virtual void Show()
        {
            _root.SetActive(true);
        }

        public void Hide()
        {
            _root.SetActive(false);
        }
    }
}