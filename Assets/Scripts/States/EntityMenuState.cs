using System.Collections;

namespace Selectica
{
    public class EntityMenuState : State
    {
        private readonly Entity _selectedEntity;

        public EntityMenuState(Entity selectedEntity)
        {
            _selectedEntity = selectedEntity;
        }

        public override IEnumerator HandleInput(Input input)
        {
            if (input != Input.MouseRightKey) yield break;
            yield return ExecutorsRegistry.ExecuteAll<IExecuteOnEntityDeselect>(_selectedEntity);
        }
    }
}