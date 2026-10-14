using System.Collections;

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
                selectable = true,
                cellIndex = new CellIndex(0, 0)
            });

            Coroutines.Start(ExecutorsRegistry.ExecuteAll<IExecuteOnEntitySpawn>(grassTileEntity));
            yield return null;
        }
    }
}