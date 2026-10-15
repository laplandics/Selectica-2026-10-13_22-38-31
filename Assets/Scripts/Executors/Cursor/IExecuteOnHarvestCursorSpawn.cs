using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnHarvestCursorSpawn
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var dataContainer = validator.ValidateAt<DataContainer<HarvestCursor>>(0);
            
            yield return ExecuteOnHarvestCursorSpawn(dataContainer);
        }

        IEnumerator ExecuteOnHarvestCursorSpawn(DataContainer<HarvestCursor> dataContainer);
    }
}