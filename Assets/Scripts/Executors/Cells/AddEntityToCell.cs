using System.Collections;
using System.Collections.Generic;

namespace Selectica
{
    [ExecutePriority(0)]
    public class AddEntityToCell : IExecuteOnEntityAddToCell
    {
        public IEnumerator ExecuteOnEntityAddToCell(Entity entity, CellIndex cellIndex)
        {
            if (G.CellsMap.TryGetValue(cellIndex, out var cell))
            {
                cell.entitiesIds.Add(entity.ID);
            }
            else
            {
                cell = new Cell(cellIndex)
                {
                    entitiesIds = new List<string> { entity.ID }
                };
                
                G.CellsMap.Add(cellIndex, cell);
            }
            
            entity.currentCell = cell;
            yield return null;
        }
    }
}