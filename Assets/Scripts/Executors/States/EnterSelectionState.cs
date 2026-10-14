using System.Collections;

namespace Selectica
{
    [ExecutePriority(100)]
    public class EnterSelectionState : IExecuteOnGameSceneLoad, IExecuteOnEntityDeselect
    {
        public IEnumerator ExecuteOnGameSceneLoad() => EnterSelectionStateRoutine();

        public IEnumerator ExecuteOnEntityDeselect(Entity entity) => EnterSelectionStateRoutine();

        private IEnumerator EnterSelectionStateRoutine() =>
            ExecutorsRegistry.ExecuteAll<IExecuteOnEnterSelectionState>();
    }
}