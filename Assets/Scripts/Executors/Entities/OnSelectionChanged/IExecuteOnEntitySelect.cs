using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnEntitySelect
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var entity = validator.ValidateAt<Entity>(0);
            
            yield return ExecuteOnEntitySelect(entity);
        }
        
        IEnumerator ExecuteOnEntitySelect(Entity entity);
    }
}