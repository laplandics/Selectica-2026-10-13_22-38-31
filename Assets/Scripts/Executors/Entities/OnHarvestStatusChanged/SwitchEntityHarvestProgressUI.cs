using System.Collections;

namespace Selectica
{
    public class SwitchEntityHarvestProgressUI : IExecuteOnEntityBeginHarvest, IExecuteOnEntityEndHarvest
    {
        public IEnumerator ExecuteOnEntityBeginHarvest(Entity entity)
        {
            yield return null;
        }
        
        public IEnumerator ExecuteOnEntityEndHarvest(Entity entity)
        {
            yield return null;
        }
    }
}