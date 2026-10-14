using System.Collections;

namespace Selectica
{
    public class SetEntityCellOnSpawn : IExecuteOnEntitySpawn
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            var cellIndex = entity.entityData.cellIndex;
            if (!cellIndex.valid) yield break;
            
            yield return ExecutorsRegistry.ExecuteAll<IExecuteOnEntityAddToCell>(entity, cellIndex);
        }
    }
}