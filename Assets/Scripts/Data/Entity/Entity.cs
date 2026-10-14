using System;
using UnityEngine;

namespace Selectica
{
    [Serializable]
    public class Entity
    {
        [Header("Inconsistent")]
        [SerializeField] private string id = Guid.NewGuid().ToString();

        [Header("Save/Load Data")]
        public EntityData entityData;

        [Header("Runtime data")]
        public EntityInstance instance;
        public GameObject meshObject;
        public GameObject selectionColliderObject;
        public Cell currentCell;
        
        public string ID => id;

        public Entity(EntityData entityData) => this.entityData = entityData;
    }
}