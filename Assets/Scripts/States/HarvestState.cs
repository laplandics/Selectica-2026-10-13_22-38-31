using System.Collections;

namespace Selectica
{
    public class HarvestState : State
    {
        private readonly HarvestCursor _cursor;

        public HarvestState(HarvestCursor cursor)
        {
            _cursor = cursor;
        }
        
        public override IEnumerator HandleInput(Input input)
        {
            yield return ExecutorsRegistry.ExecuteAll<IExecuteOnHarvestCursorDespawn>(_cursor);
        }
    }
}