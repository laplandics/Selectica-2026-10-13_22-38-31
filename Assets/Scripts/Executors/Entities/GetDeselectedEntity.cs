using System.Collections;

namespace Selectica
{
    [ExecutePriority(9)]
    public class GetDeselectedEntity : IExecuteOnDeselectInputPerformed, IExecuteOnSelectInputPerformed
    {
        public IEnumerator ExecuteOnSelectInputPerformed() => DeselectEntityRoutine();
        
        public IEnumerator ExecuteOnDeselectInputPerformed() => DeselectEntityRoutine();

        private IEnumerator DeselectEntityRoutine()
        {
            var selectedEntity = G.SelectedEntity;
            if (selectedEntity == null) yield break;

            yield return ExecutorsRegistry.ExecuteAll<IExecuteOnEntityDeselect>(selectedEntity);
        }
    }
}