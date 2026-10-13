using System.Collections;
using UnityEngine;

namespace Selectica
{
    public static class Main
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Boot() => Coroutines.Start(BootRoutine());

        private static IEnumerator BootRoutine() => Handlers.ExecuteHandlers<IOnBootHandler>();
    }
}