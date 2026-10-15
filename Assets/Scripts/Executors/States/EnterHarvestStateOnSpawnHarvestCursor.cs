using System.Collections;

namespace Selectica
{
    [ExecutePriority(100)]
    public class EnterHarvestStateOnSpawnHarvestCursor : IExecuteOnHarvestCursorSpawn
    {
        public IEnumerator ExecuteOnHarvestCursorSpawn(DataContainer<HarvestCursor> dataContainer)
        {
            yield return CurrentState.SwitchTo(new HarvestState(dataContainer.Instance));
        }
    }
}