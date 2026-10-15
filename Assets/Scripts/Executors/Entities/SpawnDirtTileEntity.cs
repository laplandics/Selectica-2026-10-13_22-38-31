using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(20)]
    public class SpawnDirtTileEntity : IExecuteOnGameSceneLoad
    {
        public IEnumerator ExecuteOnGameSceneLoad()
        {
            var dirtTileEntity = new Entity(new EntityData
            {
                hasInstance = true,
                hasMesh = true,
                meshName = "DirtTile",
                materialName = "Tile",
                positionIndex = new Vector2Int(0, 0),
                selectable = true,
                harvestable = false,
            });

            Coroutines.Start(ExecutorsRegistry.ExecuteAll<IExecuteOnEntitySpawn>(dirtTileEntity));
            yield return null;
        }
    }
}