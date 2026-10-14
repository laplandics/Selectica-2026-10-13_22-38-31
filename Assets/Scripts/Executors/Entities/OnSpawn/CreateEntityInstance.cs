using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(1)]
    public class CreateEntityInstance : IExecuteOnEntitySpawn
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            if (!entity.entityData.hasInstance) yield break;
            var instanceObject = new GameObject("Entity");
            
            var instance = instanceObject.AddComponent<EntityInstance>();
            instance.entity = entity;
            
            entity.instance = instance;
            yield return null;
        }
    }
}