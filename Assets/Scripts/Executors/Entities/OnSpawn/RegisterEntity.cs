using System.Collections;

namespace Selectica
{
    [ExecutePriority(0)]
    public class RegisterEntity : IExecuteOnEntitySpawn
    {
        public IEnumerator ExecuteOnEntitySpawn(Entity entity)
        {
            G.EntitiesMap.Add(entity.ID, entity);
            yield return null;
        }
    }
}