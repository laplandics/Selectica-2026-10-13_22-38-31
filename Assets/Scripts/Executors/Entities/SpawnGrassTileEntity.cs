using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(20)]
    public class SpawnGrassTileEntity : IExecuteOnGameSceneLoad
    {
        public IEnumerator ExecuteOnGameSceneLoad()
        {
            var grassTileEntity = new Entity(new EntityData
            {
                hasInstance = true,
                hasMesh = true,
                meshName = "GrassTile",
                materialName = "Tile",
                positionIndex = new Vector2Int(0, 0),
                selectable = true,
                harvestable = true,
                harvestSpeed = 10f,
            });

            Coroutines.Start(ExecutorsRegistry.ExecuteAll<IExecuteOnEntitySpawn>(grassTileEntity));
            yield return null;
        }
    }
}