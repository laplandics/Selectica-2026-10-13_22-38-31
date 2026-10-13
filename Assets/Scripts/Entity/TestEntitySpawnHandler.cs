using System.Collections;

namespace Selectica
{
    public class TestEntitySpawnHandler : IOnGameLoadHandler
    {
        public IEnumerator ExecuteOnGameLoad()
        {
            var testEntity1 = new Entity();
            testEntity1.hasInstance = true;
            testEntity1.hasMesh = true;
            testEntity1.meshName = "DirtTile";
            testEntity1.materialName = "Tile";
            
            Coroutines.Start(Entities.Spawn(testEntity1));
            yield return null;
            
            var testEntity2 = new Entity();
            testEntity2.hasInstance = true;
            testEntity2.hasMesh = true;
            testEntity2.meshName = "GrassTile";
            testEntity2.materialName = "Tile";
            testEntity2.selectable = true;
            
            Coroutines.Start(Entities.Spawn(testEntity2));
            yield return null;
        }
    }
}