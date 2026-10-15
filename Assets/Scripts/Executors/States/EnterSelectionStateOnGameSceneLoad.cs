using System.Collections;

namespace Selectica
{
    [ExecutePriority(100)]
    public class EnterSelectionStateOnGameSceneLoad : IExecuteOnGameSceneLoad
    {
        public IEnumerator ExecuteOnGameSceneLoad() => CurrentState.SwitchTo(new SelectionState());
    }
}