using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnEntityEndHarvest
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var entity = validator.ValidateAt<Entity>(0);

            yield return ExecuteOnEntityEndHarvest(entity);
        }
        
        IEnumerator ExecuteOnEntityEndHarvest(Entity entity);
    }
}