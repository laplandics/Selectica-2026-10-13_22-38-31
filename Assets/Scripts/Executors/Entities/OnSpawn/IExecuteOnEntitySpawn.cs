using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnEntitySpawn
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var entity = validator.ValidateAt<Entity>(0);
            
            yield return ExecuteOnEntitySpawn(entity);
        }

        IEnumerator ExecuteOnEntitySpawn(Entity entity);
    }
}