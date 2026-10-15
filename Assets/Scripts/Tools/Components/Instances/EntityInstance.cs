using UnityEngine;

namespace Selectica
{
    [SelectionBase]
    public class EntityInstance : MonoBehaviour
    {
        public Entity entity;

        private void Awake()
        {
            hideFlags = HideFlags.NotEditable;
        }
    }
}