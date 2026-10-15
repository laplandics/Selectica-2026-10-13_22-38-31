using System.Collections;

namespace Selectica
{
    [ExecutePriority(100)]
    public class EnterSelectionStateOnEntityDeselect : IExecuteOnEntityDeselect
    {
        public IEnumerator ExecuteOnEntityDeselect(Entity entity)
        {
            yield return CurrentState.SwitchTo(new SelectionState());
        }
    }
}