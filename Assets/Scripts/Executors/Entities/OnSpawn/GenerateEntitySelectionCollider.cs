using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(3)]
    public class GenerateEntitySelectionCollider : IExecuteOnEntitySpawn
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            if (!entity.entityData.selectable) yield break;

            var meshObject = entity.meshObject;
            if (meshObject == null) yield break;

            var colliderObject = new GameObject("SelectionCollider");
            colliderObject.transform.SetParent(entity.instance.transform, false);
            
            colliderObject.layer = LayerMask.NameToLayer("Selectable");
            
            var collider = colliderObject.AddComponent<BoxCollider>();
            var meshFilter = meshObject.GetComponent<MeshFilter>();
            
            collider.center = meshFilter.sharedMesh.bounds.center;
            collider.size = meshFilter.sharedMesh.bounds.size;
            
            var selectionCollider = colliderObject.AddComponent<SelectionCollider>();
            selectionCollider.entity = entity;
            
            entity.selectionColliderObject = colliderObject;
            yield return null;
        }
    }
}