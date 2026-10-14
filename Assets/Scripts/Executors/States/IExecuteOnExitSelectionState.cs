using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnExitSelectionState
    {
        IEnumerator Execute(params object[] args) => ExecuteOnExitSelectionState();
        
        IEnumerator ExecuteOnExitSelectionState();
    }
}