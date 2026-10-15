using System.Collections;
using UnityEngine;

namespace Selectica
{
    public class FinishEntityHarvest : IExecuteOnEntityBeginHarvest, IExecuteOnEntityEndHarvest
    {
        private bool _harvestInProgress;
        
        public IEnumerator ExecuteOnEntityBeginHarvest(Entity entity)
        {
            if (_harvestInProgress)
            {
                Debug.LogWarning("Entity has already began harvest");
                yield break;
            }
            
            _harvestInProgress = true;
            Coroutines.Start(HandleHarvestRoutine(entity));
            yield return null;
        }

        private IEnumerator HandleHarvestRoutine(Entity entity)
        {
            while (_harvestInProgress)
            {
                var harvest = Time.deltaTime * entity.entityData.harvestSpeed;
                entity.HarvestProgress = Mathf.Clamp(entity.HarvestProgress + harvest, 0f, 100f);
                
                if (entity.HarvestProgress >= 100f)
                {
                    Coroutines.Start(ExecutorsRegistry.ExecuteAll<IExecuteOnHarvestFinish>(entity));
                    yield break;
                }
                
                yield return null;
            }
        }
        
        public IEnumerator ExecuteOnEntityEndHarvest(Entity entity)
        {
            if (!_harvestInProgress)
            {
                Debug.LogWarning("Entity hasn't began harvest");
                yield break;
            }

            _harvestInProgress = false;
            yield return null;
        }
    }
}