using System.Collections;
using UnityEngine;

namespace Selectica
{
    public class SwitchSystemCursorVisibility : IExecuteOnHarvestCursorSpawn, IExecuteOnHarvestCursorDespawn
    {
        public IEnumerator ExecuteOnHarvestCursorSpawn(DataContainer<HarvestCursor> dataContainer)
        {
            Cursor.visible = false;
            yield return null;
        }

        public IEnumerator ExecuteOnHarvestCursorDespawn(HarvestCursor harvestCursor)
        {
            Cursor.visible = true;
            yield return null;
        }
    }
}