using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnHarvestFinish
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var entity = validator.ValidateAt<Entity>(0);
            
            yield return ExecuteOnHarvestFinish(entity);
        }

        IEnumerator ExecuteOnHarvestFinish(Entity entity);
    }
}