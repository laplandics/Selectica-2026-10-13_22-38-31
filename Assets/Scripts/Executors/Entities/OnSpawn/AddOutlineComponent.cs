using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(4)]
    public class AddOutlineComponent : IExecuteOnEntitySpawn
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            if (!entity.entityData.hasMesh) yield break;
            if (!entity.entityData.selectable) yield break;

            var meshObject = entity.meshObject;
            var outline = meshObject.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineAndSilhouette;
            outline.OutlineColor = Color.clear;
            outline.OutlineWidth = 8;
            outline.enabled = false;

            yield return null;
        }
    }
}