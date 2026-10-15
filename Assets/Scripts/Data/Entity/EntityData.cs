using System;
using UnityEngine;

namespace Selectica
{
    [Serializable]
    public struct EntityData
    {
        public bool hasInstance;
        
        public bool hasMesh;
        public string meshName;
        public string materialName;

        public Vector2Int positionIndex;
        
        public bool selectable;
        
        public bool harvestable;
        public float harvestSpeed;
    }
}