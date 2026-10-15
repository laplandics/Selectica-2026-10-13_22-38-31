using System;
using Unity.Properties;
using UnityEngine;

namespace Selectica
{
    [Serializable]
    public class Entity
    {
        [Header("Inconsistent")]
        [DontCreateProperty][SerializeField] private string id = Guid.NewGuid().ToString();

        [Header("Save/Load Data")]
        [DontCreateProperty] public EntityData entityData;

        [Header("Runtime data")]
        [DontCreateProperty] public EntityInstance instance;
        [DontCreateProperty] public GameObject meshObject;
        [DontCreateProperty] public GameObject selectionColliderObject;
        [DontCreateProperty] public GameObject harvestColliderObject;
        [DontCreateProperty] public Outline outline;
        
        public string ID => id;

        public Entity(EntityData entityData) => this.entityData = entityData;

        [CreateProperty] public string Name => entityData.meshName;
        [CreateProperty] public float HarvestProgress { get; set; }
    }
}