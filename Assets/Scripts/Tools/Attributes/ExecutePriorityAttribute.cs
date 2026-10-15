using System;

namespace Selectica
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ExecutePriorityAttribute : Attribute
    {
        public int Priority { get; }
        public Type InterfaceType { get; }

        public ExecutePriorityAttribute(int priority)
        {
            Priority = priority;
        }

        public ExecutePriorityAttribute(Type interfaceType, int priority)
        {
            InterfaceType = interfaceType;
            Priority = priority;
        }
    }
}