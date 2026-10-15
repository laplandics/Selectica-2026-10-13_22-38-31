using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnEntityBeginHarvest
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var entity = validator.ValidateAt<Entity>(0);
            
            yield return ExecuteOnEntityBeginHarvest(entity);
        }

        IEnumerator ExecuteOnEntityBeginHarvest(Entity entity);
    }
}