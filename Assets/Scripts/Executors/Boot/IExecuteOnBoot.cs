using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnBoot
    {
        IEnumerator Execute(params object[] args) => ExecuteOnBoot();
        
        IEnumerator ExecuteOnBoot();
    }
}