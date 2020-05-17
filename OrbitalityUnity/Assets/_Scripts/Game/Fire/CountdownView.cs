using UnityEngine;
using UnityEngine.UI;

namespace Game.Fire
{
    public class CountdownView : MonoBehaviour
    {
        [SerializeField] Text _countdown;

        public void UpdateTime(float time)
        {
            var isVisible = time > 0 && !Mathf.Approximately(time, 0);
            _countdown.gameObject.SetActive(isVisible);
            if(isVisible)
                _countdown.text = time.ToString("0.0");
        }
    }
}