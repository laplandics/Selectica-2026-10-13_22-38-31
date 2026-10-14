using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Selectica
{
    public static class R
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Reload()
        {
            AssetsLoader<GameObject>.LoadAssets("Prefabs");
            AssetsLoader<VisualTreeAsset>.LoadAssets("UIAssets");
            AssetsLoader<Material>.LoadAssets("Materials");
            AssetsLoader<Mesh>.LoadAssets("Meshes");
        }
        
        public static class AssetsLoader<T> where T : Object
        {
            private static readonly Dictionary<string, T> AssetsMap = new();

            public static void LoadAssets(string folder)
            {
                AssetsMap.Clear();
                var assets = Resources.LoadAll<T>(folder);
                
                foreach (var asset in assets)
                { AssetsMap.Add(asset.name, asset); }
            }
            
            public static T GetAsset(string name) => AssetsMap[name];
        }
    }
}