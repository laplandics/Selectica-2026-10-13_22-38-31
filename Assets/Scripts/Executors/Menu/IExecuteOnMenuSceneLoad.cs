using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnMenuSceneLoad
    {
        IEnumerator Execute(params object[] args) => ExecuteOnMenuSceneLoad();
        
        IEnumerator ExecuteOnMenuSceneLoad();
    }
}