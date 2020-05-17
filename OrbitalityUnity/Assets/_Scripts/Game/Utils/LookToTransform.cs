using UnityEngine;

namespace Game.Utils
{
    public class LookToTransform : MonoBehaviour
    {
        public Transform TransformToLook;

        private void Update()
        {
            if (!TransformToLook)
                return;

            transform.LookAt(TransformToLook);
        }
    }
}