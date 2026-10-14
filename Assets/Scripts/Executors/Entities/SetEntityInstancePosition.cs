using System.Collections;
using UnityEngine;

namespace Selectica
{
    public class SetEntityInstancePosition : IExecuteOnEntityAddToCell
    {
        public IEnumerator ExecuteOnEntityAddToCell(Entity entity, CellIndex cellIndex)
        {
            var gridPosition = new Vector2Int(cellIndex.x, cellIndex.z);
            var worldPosition = Grid.GridToWorldCenter(gridPosition);

            if (entity.entityData.hasInstance)
            {
                entity.instance.transform.position = worldPosition;
            }
            
            yield return null;
        }
    }
}