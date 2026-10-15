using System.Collections;

namespace Selectica
{
    public static class CurrentState
    {
        private static State _instance;
        
        public static IEnumerator SwitchTo(State stateInstance)
        {
            if (_instance != null)
            {
                yield return _instance.ExitState();
            }
            
            _instance = stateInstance;
            yield return stateInstance.EnterState();
        }

        public static IEnumerator HandleInput(Input input)
        {
            if (_instance == null) yield break;
            yield return _instance.HandleInput(input);
        }
    }
}