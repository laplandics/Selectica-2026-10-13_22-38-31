using System.Collections;

namespace Selectica
{
    [ExecutePriority(100)]
    public class EnterSelectionStateOnHarvestCursorDespawn : IExecuteOnHarvestCursorDespawn
    {
        public IEnumerator ExecuteOnHarvestCursorDespawn(HarvestCursor cursor)
        {
            yield return CurrentState.SwitchTo(new SelectionState());
        }
    }
}