using System.Collections;
using UnityEngine;

namespace Selectica
{
    public class SwitchEntitySelectionHighlight : IExecuteOnEntitySelect, IExecuteOnEntityDeselect
    {
        public IEnumerator ExecuteOnEntitySelect(DataContainer<Entity> dataContainer)
        {
            var entity = dataContainer.Instance;
            var outline = entity.outline;
            
            outline.OutlineColor = Color.white;
            outline.enabled = true;
            yield return null;
        }

        public IEnumerator ExecuteOnEntityDeselect(Entity entity)
        {
            var outline = entity.outline;

            outline.OutlineColor = Color.clear;
            outline.enabled = false;
            yield return null;
        }
    }
}