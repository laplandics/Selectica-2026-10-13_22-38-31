using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Selectica
{
    public class SelectionState : State
    {
        private bool _leftKeyPressed;
        
        public override IEnumerator HandleInput(Input input)
        {
            var mouse = Mouse.current;
            
            switch (input)
            {
                case Input.MouseLeftKey:
                    _leftKeyPressed = true;
                    yield return TrySpawnHarvestCursor(mouse);
                    break;
                
                case Input.None:
                    if (_leftKeyPressed)
                    {
                        _leftKeyPressed = false;
                        yield return TrySelectEntity();
                    }
                    break;
            }
            
            yield return null;
        }

        private IEnumerator TrySelectEntity()
        {
            yield return ExecutorsRegistry.ExecuteAll<IExecuteOnEntitySelect>(new DataContainer<Entity>());
        }

        private IEnumerator TrySpawnHarvestCursor(Mouse mouse)
        {
            var startPos = mouse.position.ReadValue();
            
            while (_leftKeyPressed)
            {
                var delta = mouse.position.ReadValue() - startPos;
                if (delta.sqrMagnitude > 1500f)
                {
                    yield return ExecutorsRegistry.ExecuteAll<IExecuteOnHarvestCursorSpawn>(
                        new DataContainer<HarvestCursor>());
                    
                    yield break;
                }
                
                yield return null;
            }
        }

        public override IEnumerator ExitState()
        {
            _leftKeyPressed = false;
            yield return null;
        }
    }
}