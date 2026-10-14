using System;

namespace Selectica
{
    [Serializable]
    public struct EntityData
    {
        public bool hasInstance;
        
        public bool hasMesh;
        public string meshName;
        public string materialName;
        
        public CellIndex cellIndex;
        
        public bool selectable;
    }
}