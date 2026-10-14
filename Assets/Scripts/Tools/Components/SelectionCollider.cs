using UnityEngine;

namespace Selectica
{
    public class SelectionCollider : MonoBehaviour
    {
        public string bindEntityId;

        private void Awake()
        {
            hideFlags = HideFlags.NotEditable;
        }
    }
}