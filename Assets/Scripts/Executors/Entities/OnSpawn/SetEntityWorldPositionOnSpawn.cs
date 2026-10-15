using System.Collections;

namespace Selectica
{
    [ExecutePriority(2)]
    public class SetEntityWorldPositionOnSpawn : IExecuteOnEntitySpawn
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            var gridPosition = entity.entityData.positionIndex;
            var worldPosition = Grid.GridToWorldCenter(gridPosition);

            if (entity.entityData.hasInstance)
            {
                entity.instance.transform.position = worldPosition;
            }
            
            yield return null;
        }
    }
}