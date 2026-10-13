using System.Collections;

namespace Selectica
{
    public static class Entities
    {
        public static IEnumerator Spawn(Entity entity)
        {
            yield return Handlers.ExecuteHandlers<IOnEntitySpawnHandler>(entity);
            yield return null;
        }

        public static IEnumerator Despawn(Entity entity)
        {
            yield return null;
        }
    }
}