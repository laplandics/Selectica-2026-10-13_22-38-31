using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(2)]
    public class LoadEntityMesh : IExecuteOnEntitySpawn
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            if (!entity.entityData.hasMesh) yield break;
            
            var instance = entity.instance;
            if (instance == null) yield break;
            
            var mesh = R.AssetsLoader<Mesh>.GetAsset(entity.entityData.meshName);
            var material = R.AssetsLoader<Material>.GetAsset(entity.entityData.materialName);

            var meshObject = new GameObject("Mesh");
            meshObject.transform.SetParent(instance.transform, false);
            
            var meshFilter = meshObject.AddComponent<MeshFilter>();
            var meshRenderer = meshObject.AddComponent<MeshRenderer>();
            
            meshFilter.sharedMesh = mesh;
            meshRenderer.sharedMaterial = material;
            
            entity.meshObject = meshObject;
            yield return null;
        }
    }
}