using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnEnterSelectionState
    {
        IEnumerator Execute(params object[] args) => ExecuteOnEnterSelectionState();
        
        IEnumerator ExecuteOnEnterSelectionState();
    }
}