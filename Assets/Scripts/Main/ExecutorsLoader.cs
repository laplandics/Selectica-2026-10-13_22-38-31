using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Selectica
{
    public static class ExecutorsLoader
    {
        private const int DEFAULT_PRIORITY = 50;
        private const string EXECUTION_ROUTINE_BASE_NAME = "Execute";

        private static readonly Type[] ExecuteParameterTypes = { typeof(object[]) };
        
        public static Dictionary<Type, List<Func<object[], IEnumerator>>> Load()
        {
            var map = new Dictionary<Type, List<Func<object[], IEnumerator>>>();
            
            var interfaces = new List<Type>();
            var candidates = new List<Type>();
            foreach (var type in GetAllTypes())
            {
                if (type.IsInterface)
                {
                    if (type.IsDefined(typeof(ExecuteAutoAttribute), false))
                        interfaces.Add(type);
                }
                else if (type.IsClass && !type.IsAbstract && !type.ContainsGenericParameters
                         && !typeof(UnityEngine.Object).IsAssignableFrom(type))
                {
                    candidates.Add(type);
                }
            }

            var cachedInstances = new Dictionary<Type, object>();
            foreach (var interfaceType in interfaces)
            {
                var routine = interfaceType.GetMethod(EXECUTION_ROUTINE_BASE_NAME, ExecuteParameterTypes);
                if (routine == null || routine.ReturnType != typeof(IEnumerator))
                {
                    Debug.LogError($"{interfaceType.Name} has {nameof(ExecuteAutoAttribute)} " +
                                   $"but no 'IEnumerator {EXECUTION_ROUTINE_BASE_NAME}(params object[] args)' found.");
                    continue;
                }

                var inheritors = candidates
                    .Where(interfaceType.IsAssignableFrom)
                    .OrderBy(t => GetPriority(t, interfaceType))
                    .ThenBy(t => t.FullName, StringComparer.Ordinal);

                var list = new List<Func<object[], IEnumerator>>();
                foreach (var inheritor in inheritors)
                {
                    var instance = GetOrCreateInstance(inheritor, cachedInstances);
                    if (instance == null) continue;
                    
                    list.Add((Func<object[], IEnumerator>)routine
                        .CreateDelegate(typeof(Func<object[], IEnumerator>), instance));
                }

                map[interfaceType] = list;
            }
            
            return map;
        }

        private static int GetPriority(Type classType, Type interfaceType)
        {
            int? general = null;
            foreach (var attr in classType.GetCustomAttributes<ExecutePriorityAttribute>(false))
            {
                if (attr.InterfaceType != null && (!attr.InterfaceType.IsInterface ||
                !attr.InterfaceType.IsAssignableFrom(classType)))
                {
                    Debug.LogWarning($"{classType.Name}: {nameof(ExecutePriorityAttribute)} references " +
                                     $"{attr.InterfaceType.Name}, which the class does not implement.");
                }
                
                if (attr.InterfaceType == interfaceType) return attr.Priority;
                if (attr.InterfaceType == null) general = attr.Priority;
            }
            
            return general ?? DEFAULT_PRIORITY;
        }

        private static IEnumerable<Type> GetAllTypes()
        {
            foreach (var assembly in UnityEngine.Assemblies.CurrentAssemblies.GetLoadedAssemblies())
            {
                if (assembly.IsDynamic) continue;

                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException e)
                {
                    types = e.Types.Where(t => t != null).ToArray();
                }

                foreach (var type in types)
                    yield return type;
            }
        }
        
        private static object GetOrCreateInstance(Type type, Dictionary<Type, object> cache)
        {
            if (cache.TryGetValue(type, out var existing))
                return existing;

            try
            {
                var instance = Activator.CreateInstance(type, true);
                cache[type] = instance;
                return instance;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to create executor {type.FullName}: {e}");
                cache[type] = null;
                return null;
            }
        }
    }
}