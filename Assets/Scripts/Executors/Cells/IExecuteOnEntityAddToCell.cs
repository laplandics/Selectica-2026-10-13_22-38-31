using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnEntityAddToCell
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var entityId = validator.ValidateAt<Entity>(0);
            var cellIndex = validator.ValidateAt<CellIndex>(1);
            
            yield return ExecuteOnEntityAddToCell(entityId, cellIndex);
        }
        
        IEnumerator ExecuteOnEntityAddToCell(Entity entity, CellIndex cellIndex);
    }
}