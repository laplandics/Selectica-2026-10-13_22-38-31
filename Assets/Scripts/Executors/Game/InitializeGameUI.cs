using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Selectica
{
    [ExecutePriority(0)]
    public class InitializeGameUI : IExecuteOnGameSceneLoad
    {
        private VisualElement _screenSpaceUIRoot;
        
        public IEnumerator ExecuteOnGameSceneLoad()
        {
            _screenSpaceUIRoot = null;
            
            var uiObject = new GameObject("UI");
            var renderer = uiObject.AddComponent<PanelRenderer>();
            
            renderer.RegisterUIReloadCallback(OnUIReady);
            
            renderer.panelSettings = R.AssetsLoader<PanelSettings>.GetAsset("UISettings");
            renderer.visualTreeAsset = R.AssetsLoader<VisualTreeAsset>.GetAsset("GameUIRoot");
            
            yield return new WaitUntil(() => _screenSpaceUIRoot != null);
            yield return ExecutorsRegistry.ExecuteAll<IExecuteOnGameScreenSpaceUIReady>(_screenSpaceUIRoot);
        }

        private void OnUIReady(PanelRenderer renderer, VisualElement root, int _)
        {
            renderer.UnregisterUIReloadCallback(OnUIReady);
            _screenSpaceUIRoot = root.Q<VisualElement>("ROOT");
        }
    }
}