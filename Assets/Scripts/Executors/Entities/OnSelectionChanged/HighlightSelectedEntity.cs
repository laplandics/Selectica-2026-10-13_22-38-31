using System.Collections;
using UnityEngine;

namespace Selectica
{
    public class HighlightSelectedEntity : IExecuteOnEntitySelect, IExecuteOnEntityDeselect
    {
        public IEnumerator ExecuteOnEntitySelect(Entity entity)
        {
            var outline = entity.meshObject.GetComponent<Outline>();
            
            outline.OutlineColor = Color.white;
            outline.enabled = true;
            yield return null;
        }

        public IEnumerator ExecuteOnEntityDeselect(Entity entity)
        {
            var outline = entity.meshObject.GetComponent<Outline>();

            outline.OutlineColor = Color.clear;
            outline.enabled = false;
            yield return null;
        }
    }
}