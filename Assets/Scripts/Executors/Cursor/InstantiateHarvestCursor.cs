using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(0)]
    public class InstantiateHarvestCursor : IExecuteOnHarvestCursorSpawn
    {
        public IEnumerator ExecuteOnHarvestCursorSpawn(DataContainer<HarvestCursor> dataContainer)
        {
            var prefab = R.AssetsLoader<GameObject>.GetAsset("HarvestCursor");
            
            var cursorObject = Object.Instantiate(prefab);
            cursorObject.name = "Cursor";
            
            var harvestCursor = cursorObject.GetComponent<HarvestCursor>();
            harvestCursor.Activate();
            
            dataContainer.Instance = harvestCursor;
            yield return null;
        }
    }
}