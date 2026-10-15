using System.Collections;

namespace Selectica
{
    [ExecutePriority(100)]
    public class EnterEntityMenuStateOnEntitySelect : IExecuteOnEntitySelect
    {
        public IEnumerator ExecuteOnEntitySelect(DataContainer<Entity> dataContainer)
        {
            var state = new EntityMenuState(dataContainer.Instance);
            yield return CurrentState.SwitchTo(state);
        }
    }
}