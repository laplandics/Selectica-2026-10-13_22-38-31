using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Selectica
{
    [ExecutePriority(0)]
    public class SelectEntity : IExecuteOnEntitySelect
    {
        public IEnumerator ExecuteOnEntitySelect(DataContainer<Entity> dataContainer)
        {
            var camera = Camera.main;
            var mouse = Mouse.current;
            
            if (camera == null || mouse == null)
            {
                ExecutorsRegistry.BrakeCurrentExecutions();
                yield break;
            }
            
            var mousePos = mouse.position.ReadValue();
            var ray = camera.ScreenPointToRay(mousePos);

            var mask = LayerMask.GetMask("Selectable");
            
            var entityFound = false;
            if (Physics.Raycast(ray, out var hit, 100, mask))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.TryGetComponent<SelectionCollider>(out var selectionCollider))
                    {
                        dataContainer.Instance = selectionCollider.entity;
                        entityFound = true;
                    }
                }
            }
            
            if (!entityFound) ExecutorsRegistry.BrakeCurrentExecutions();
        }
    }
}