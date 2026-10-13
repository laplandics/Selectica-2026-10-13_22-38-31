using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Selectica
{
    public static class Handlers
    {
        private static Dictionary<Type, List<IHandler>> _handlersMap = new();
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Load() => HandlersLoader.GetHandlersMap(out _handlersMap);

        public static IEnumerator ExecuteHandlers<T>(params object[] args) where T : IHandler
        {
            var handlers = _handlersMap[typeof(T)];
            foreach (var handler in handlers)
            {
                yield return Coroutines.Start(handler.Execute(args));
                yield return null;
            }
        }
    }
}