using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnEntitySelect
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var container = validator.ValidateAt<DataContainer<Entity>>(0);
            
            yield return ExecuteOnEntitySelect(container);
        }
        
        IEnumerator ExecuteOnEntitySelect(DataContainer<Entity> dataContainer);
    }
}