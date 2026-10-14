using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Selectica
{
    [ExecutePriority(100)]
    public class SwitchSelectionStateInputs : IExecuteOnEnterSelectionState, IExecuteOnExitSelectionState
    {
        private bool _active;
        private InputActions _inputActions;
        
        public IEnumerator ExecuteOnEnterSelectionState()
        {
            if (_active)
            {
                Debug.LogWarning("Selection inputs were already activated");
                yield break;
            }
            
            _active = true;
            
            _inputActions = new InputActions();
            _inputActions.Selection.Enable();
            
            _inputActions.Selection.Select.performed += OnSelectInputPerformed;
            
            yield return null;
        }

        private void OnSelectInputPerformed(InputAction.CallbackContext ctx)
        {
            Coroutines.Start(ExecutorsRegistry.ExecuteAll<IExecuteOnSelectInputPerformed>());
        }

        public IEnumerator ExecuteOnExitSelectionState()
        {
            if (!_active)
            {
                Debug.LogWarning("Selection inputs were not activated or have been already deactivated");
                yield break;
            }
            
            _active = false;
            
            _inputActions.Selection.Select.performed -= OnSelectInputPerformed;
            
            _inputActions.Selection.Disable();
            
            yield return null;
        }
    }
}