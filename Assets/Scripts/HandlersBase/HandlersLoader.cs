using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Selectica
{
    public static class HandlersLoader
    {
        private static bool Initialized { get; set; }
        private static readonly Dictionary<Type, List<IHandler>> Cache = new();
        
        public static void GetHandlersMap(out Dictionary<Type, List<IHandler>> handlersMap)
        {
            handlersMap = Cache;
            if (Initialized) return;

            var interfaces = LoadIHandlerInterfaces();
            var classes = LoadIHandlers();

            foreach (var i in interfaces)
            {
                var handlersUnsorted = new List<IHandler>();
                foreach (var c in classes)
                {
                    if (!i.IsAssignableFrom(c.GetType())) continue;
                    handlersUnsorted.Add(c);
                }
                
                handlersMap[i] = handlersUnsorted.OrderBy(GetPriority).ToList();
            }
            
            Initialized = true;
            return;
            int GetPriority(IHandler h)
            {
                var type = h.GetType();
                var executePriorityAttr = type.GetCustomAttribute<ExecutePriorityAttribute>();
                return executePriorityAttr?.Priority ?? 10;
            }
        }
        
        private static List<Type> LoadIHandlerInterfaces()
        {
            var iHandlers = new List<Type>();
            var assemblies = UnityEngine.Assemblies.CurrentAssemblies.GetLoadedAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                iHandlers.AddRange(types.Where(t => t.IsInterface &&
                t != typeof(IHandler) && typeof(IHandler).IsAssignableFrom(t)));
            }
            
            return iHandlers;
        }
        
        private static List<IHandler> LoadIHandlers()
        {
            var handlers = new List<Type>();
            var assemblies = UnityEngine.Assemblies.CurrentAssemblies.GetLoadedAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                handlers.AddRange(types.Where(t => t.IsClass && !t.IsAbstract &&
                typeof(IHandler).IsAssignableFrom(t)));
            }
            
            var iHandlers = handlers.Select(h => Activator.CreateInstance(h) as IHandler).ToList();
            return iHandlers;
        }
    }
}