using System.Collections;
using UnityEngine.UIElements;

namespace Selectica
{
    public class SwitchEntityManagementMenu : IExecuteOnGameScreenSpaceUIReady, IExecuteOnEntitySelect, IExecuteOnEntityDeselect
    {
        private VisualElement _screenSpaceUIRoot;
        private VisualElement _entityManagementMenu;
        
        public IEnumerator ExecuteOnGameScreenSpaceUIReady(VisualElement uiRoot)
        {
            _screenSpaceUIRoot = uiRoot;
            yield return null;
        }
        
        public IEnumerator ExecuteOnEntitySelect(DataContainer<Entity> dataContainer)
        {
            var entityManagementMenuAsset = R.AssetsLoader<VisualTreeAsset>.GetAsset("EntityManagementMenu");
            _entityManagementMenu = entityManagementMenuAsset.Instantiate().Q<VisualElement>("UIElement");
            _entityManagementMenu.dataSource = dataContainer.Instance;
            
            _screenSpaceUIRoot.Add(_entityManagementMenu);
            yield return null;
        }

        public IEnumerator ExecuteOnEntityDeselect(Entity entity)
        {
            _screenSpaceUIRoot.Remove(_entityManagementMenu);
            yield return null;
        }
    }
}