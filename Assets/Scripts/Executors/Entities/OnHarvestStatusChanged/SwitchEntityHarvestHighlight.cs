using System.Collections;
using UnityEngine;

namespace Selectica
{
    public class SwitchEntityHarvestHighlight : IExecuteOnEntityBeginHarvest, IExecuteOnEntityEndHarvest
    {
        public IEnumerator ExecuteOnEntityBeginHarvest(Entity entity)
        {
            var outline = entity.outline;

            outline.OutlineWidth = 10;
            outline.OutlineColor = Color.lawnGreen;
            outline.enabled = true;
            yield return null;
        }

        public IEnumerator ExecuteOnEntityEndHarvest(Entity entity)
        {
            var outline = entity.outline;

            outline.OutlineWidth = 10;
            outline.OutlineColor = Color.clear;
            outline.enabled = false;
            yield return null;
        }
    }
}