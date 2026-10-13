using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(0)]
    public class EntityInstanceCreateHandler : IOnEntitySpawnHandler
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            if (!entity.hasInstance) yield break;
            var instance = new GameObject("Entity");
            entity.instance = instance;
        }
    }

    [ExecutePriority(1)]
    public class EntityMeshCreateHandler : IOnEntitySpawnHandler
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            if (!entity.hasMesh) yield break;
            
            var mesh = R.AssetsLoader<Mesh>.GetAsset(entity.meshName);
            var material = R.AssetsLoader<Material>.GetAsset(entity.materialName);
            
            var meshObject = new GameObject("Mesh");
            meshObject.transform.SetParent(entity.instance.transform, false);
            
            var meshFilter = meshObject.AddComponent<MeshFilter>();
            var meshRenderer = meshObject.AddComponent<MeshRenderer>();
            
            meshFilter.sharedMesh = mesh;
            meshRenderer.sharedMaterial = material;
            
            entity.meshObject = meshObject;
            yield return null;
        }
    }
    
    [ExecutePriority(2)]
    public class EntitySelectionColliderCreateHandler : IOnEntitySpawnHandler
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            if (!entity.selectable) yield break;
            
            var colliderObject = new GameObject("SelectionCollider");
            colliderObject.transform.SetParent(entity.instance.transform, false);
            
            var meshFilter = entity.meshObject.GetComponent<MeshFilter>();
            var collider = colliderObject.AddComponent<BoxCollider>();
            
            collider.center = meshFilter.sharedMesh.bounds.center;
            collider.size = meshFilter.sharedMesh.bounds.size;
            
            colliderObject.layer = LayerMask.NameToLayer("Selectable");
            
            entity.selectionColliderObject = colliderObject;
            yield return null;
        }
    }
}