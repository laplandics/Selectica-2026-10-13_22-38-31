using System;

namespace Selectica
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ExecutePriorityAttribute : Attribute
    {
        public int Priority { get; private set; }
        
        public ExecutePriorityAttribute(int priority)
        {
            Priority = priority;
        }
    }
}