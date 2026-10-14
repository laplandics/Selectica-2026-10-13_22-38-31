using System.Collections;

namespace Selectica
{
    [ExecutePriority(0)]
    public class ChangeGlobalSelectedEntity : IExecuteOnEntityDeselect, IExecuteOnEntitySelect
    {
        public IEnumerator ExecuteOnEntityDeselect(Entity entity)
        {
            G.SelectedEntity = null;
            yield return null;
        }

        public IEnumerator ExecuteOnEntitySelect(Entity entity)
        {
            G.SelectedEntity = entity;
            yield return null;
        }
    }
}