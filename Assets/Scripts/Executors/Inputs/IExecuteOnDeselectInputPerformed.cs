using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnDeselectInputPerformed
    {
        IEnumerator Execute(params object[] args) => ExecuteOnDeselectInputPerformed();
        
        IEnumerator ExecuteOnDeselectInputPerformed();
    }
}