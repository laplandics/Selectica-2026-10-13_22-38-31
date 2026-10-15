using System.Collections;
using UnityEngine.InputSystem;

namespace Selectica
{
    public class RunInputsProcessing : IExecuteOnBoot
    {
        private Input _lastSentInput = Input.None;
        
        public IEnumerator ExecuteOnBoot()
        {
            Coroutines.Start(ProcessInputsRoutine());
            yield return null;
        }

        private IEnumerator ProcessInputsRoutine()
        {
            var mouse = Mouse.current;
            
            while (true)
            {
                if (mouse.leftButton.isPressed)
                {
                    if (_lastSentInput != Input.MouseLeftKey)
                    {
                        _lastSentInput = Input.MouseLeftKey;
                        Coroutines.Start(CurrentState.HandleInput(Input.MouseLeftKey));
                    }
                }
                else if (mouse.rightButton.isPressed)
                {
                    if (_lastSentInput != Input.MouseRightKey)
                    {
                        _lastSentInput = Input.MouseRightKey;
                        Coroutines.Start(CurrentState.HandleInput(Input.MouseRightKey));
                    }
                }
                else if (mouse.middleButton.isPressed)
                {
                    if (_lastSentInput != Input.MouseMiddleKey)
                    {
                        _lastSentInput = Input.MouseMiddleKey;
                        Coroutines.Start(CurrentState.HandleInput(Input.MouseMiddleKey));
                    }
                }
                else
                {
                    if (_lastSentInput != Input.None)
                    {
                        _lastSentInput = Input.None;
                        Coroutines.Start(CurrentState.HandleInput(Input.None));
                    }
                }

                yield return null;
            }
        }
    }
}