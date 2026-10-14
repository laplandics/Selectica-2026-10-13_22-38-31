using System;

namespace Selectica
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExecutePriorityAttribute : Attribute
    {
        public int Priority { get; }

        public ExecutePriorityAttribute(int priority)
        {
            Priority = priority;
        }
    }
}