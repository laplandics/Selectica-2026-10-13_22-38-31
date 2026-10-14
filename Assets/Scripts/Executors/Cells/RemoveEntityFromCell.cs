using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(0)]
    public class RemoveEntityFromCell : IExecuteOnEntityRemoveFromCell
    {
        public IEnumerator ExecuteOnEntityRemoveFromCell(Entity entity, CellIndex cellIndex)
        {
            if (!G.CellsMap.TryGetValue(cellIndex, out var cell))
            {
                Debug.LogWarning($"Couldn't remove entity from cell {cellIndex}. Cell not found");
                yield break;
            }

            var id = entity.ID;
            if (!cell.entitiesIds.Remove(id))
            {
                Debug.LogWarning($"Couldn't remove entity from cell {cellIndex}. Cell doesn't contain entity id ({id})");
                yield break;
            }

            entity.currentCell = null;
            yield return null;
        }
    }
}