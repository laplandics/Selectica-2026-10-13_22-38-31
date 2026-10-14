using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnEntityRemoveFromCell
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var entity = validator.ValidateAt<Entity>(0);
            var cellIndex = validator.ValidateAt<CellIndex>(1);

            yield return ExecuteOnEntityRemoveFromCell(entity, cellIndex);
        }
        
        IEnumerator ExecuteOnEntityRemoveFromCell(Entity entity, CellIndex cellIndex);
    }
}