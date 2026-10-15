using System.Collections;
using UnityEngine;

namespace Selectica
{
    public class DestroyHarvestCursor : IExecuteOnHarvestCursorDespawn
    {
        public IEnumerator ExecuteOnHarvestCursorDespawn(HarvestCursor harvestCursor)
        {
            yield return harvestCursor.StopHarvest();
            Object.Destroy(harvestCursor.gameObject);
            yield return null;
        }
    }
}