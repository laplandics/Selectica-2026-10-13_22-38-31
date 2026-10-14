using System.Collections;

namespace Selectica
{
    public class ExitSelectionState : IExecuteOnEntitySelect
    {
        public IEnumerator ExecuteOnEntitySelect(Entity entity) =>
            ExecutorsRegistry.ExecuteAll<IExecuteOnExitSelectionState>();
    }
}