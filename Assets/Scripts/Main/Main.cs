using UnityEngine;

namespace Selectica
{
    public static class Main
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Bootstrap() => Coroutines.Start(ExecutorsRegistry.ExecuteAll<IExecuteOnBoot>());
    }
}