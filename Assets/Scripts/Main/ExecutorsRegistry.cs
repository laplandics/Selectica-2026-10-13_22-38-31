using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Selectica
{
    public static class ExecutorsRegistry
    {
        private static Dictionary<Type, List<Func<object[], IEnumerator>>> _executorsRoutinesMap = new();
        private static bool _brakeExecutors;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Load() => _executorsRoutinesMap = ExecutorsLoader.Load();

        public static IEnumerator ExecuteAll<T>(params object[] args)
        {
            if (!_executorsRoutinesMap.TryGetValue(typeof(T), out var routines))
            {
                Debug.LogError($"{typeof(T).Name} is not registered. Is it marked with {nameof(ExecuteAutoAttribute)}?");
                yield break;
            }

            _brakeExecutors = false;
            foreach (var routine in routines)
            {
                var enumerator = routine(args);
                while (enumerator.MoveNext() && !_brakeExecutors)
                {
                    yield return enumerator.Current;
                }
            }
        }
        
        public static void BrakeCurrentExecutions() => _brakeExecutors = true;
    }
}