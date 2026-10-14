using System.Collections;

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
                selectable = true,
                cellIndex = new CellIndex(0, 0)
            });

            Coroutines.Start(ExecutorsRegistry.ExecuteAll<IExecuteOnEntitySpawn>(dirtTileEntity));
            yield return null;
        }
    }
}