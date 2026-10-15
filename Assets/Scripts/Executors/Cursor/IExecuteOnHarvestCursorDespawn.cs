using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnHarvestCursorDespawn
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var harvestCursor = validator.ValidateAt<HarvestCursor>(0);
            
            yield return ExecuteOnHarvestCursorDespawn(harvestCursor);
        }

        IEnumerator ExecuteOnHarvestCursorDespawn(HarvestCursor cursor);
    }
}