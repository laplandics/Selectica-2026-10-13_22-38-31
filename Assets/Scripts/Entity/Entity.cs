using System;
using UnityEngine;

namespace Selectica
{
    [Serializable]
    public class Entity
    {
        public string ID { get; } = Guid.NewGuid().ToString();
        
        public bool hasInstance;
        public GameObject instance;

        public bool hasMesh;
        public string meshName;
        public string materialName;
        public GameObject meshObject;

        public bool selectable;
        public GameObject selectionColliderObject;
    }
}