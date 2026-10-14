using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnGameSceneLoad
    {
        IEnumerator Execute(params object[] args) => ExecuteOnGameSceneLoad();
        
        IEnumerator ExecuteOnGameSceneLoad();
    }
}