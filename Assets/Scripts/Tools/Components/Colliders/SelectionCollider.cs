using UnityEngine;

namespace Selectica
{
    public class SelectionCollider : MonoBehaviour
    {
        public Entity entity;

        private void Awake()
        {
            hideFlags = HideFlags.NotEditable;
        }
    }
}