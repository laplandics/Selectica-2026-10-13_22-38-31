using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Selectica
{
    [ExecutePriority(10)]
    public class GetSelectedEntity : IExecuteOnSelectInputPerformed
    {
        private readonly int _mask = LayerMask.GetMask("Selectable");
        
        public IEnumerator ExecuteOnSelectInputPerformed()
        {
            var camera = G.MainCamera;
            var mouse = Mouse.current;

            if (camera == null || mouse == null)
            {
                Debug.LogError("Selection performed, but no camera or mouse found.");
                yield break;
            }

            var mousePosition = mouse.position.ReadValue();
            var ray = camera.ScreenPointToRay(mousePosition);
            
            if (!Physics.Raycast(ray, out var hit, 100, _mask)) yield break;
            var collider = hit.collider;
            if (collider == null) yield break; 
            if (!collider.TryGetComponent<SelectionCollider>(out var selection)) yield break;
            
            var selectedEntityId = selection.bindEntityId;
            if (!G.EntitiesMap.TryGetValue(selectedEntityId, out var entity))
            {
                Debug.LogError($"Selected entity {selectedEntityId} not found");
                yield break;
            }

            yield return ExecutorsRegistry.ExecuteAll<IExecuteOnEntitySelect>(entity);
        }
    }
}