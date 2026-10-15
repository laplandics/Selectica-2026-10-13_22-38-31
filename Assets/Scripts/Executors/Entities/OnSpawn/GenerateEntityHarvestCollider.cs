using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(3)]
    public class GenerateEntityHarvestCollider : IExecuteOnEntitySpawn
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            if (!entity.entityData.harvestable) yield break;
            
            var meshObject = entity.meshObject;
            if (meshObject == null) yield break;

            var colliderObject = new GameObject("HarvestCollider");
            colliderObject.transform.SetParent(entity.instance.transform, false);
            
            colliderObject.layer = LayerMask.NameToLayer("Harvestable");
            
            var collider = colliderObject.AddComponent<SphereCollider>();
            var meshFilter = meshObject.GetComponent<MeshFilter>();

            var center = meshFilter.sharedMesh.bounds.center;
            center.y = 0;
            
            collider.center = center;
            collider.radius = 0.05f;
            
            var harvestCollider = colliderObject.AddComponent<HarvestCollider>();
            harvestCollider.entity = entity;
            
            entity.harvestColliderObject = colliderObject;
            yield return null;
        }
    }
}