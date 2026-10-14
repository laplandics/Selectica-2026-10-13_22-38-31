using System;

namespace Selectica
{
    public class ExecuteException : Exception
    {
        public string ExecutorName { get; }
        public string ExpectedArgName { get; }
        public string ReceivedArg { get; }

        public ExecuteException(Type executorType, Type expectedArgType, object arg)
            : base($"{executorType.Name}: wrong argument type {arg}. Expected: {expectedArgType.Name}")
        {
            ExecutorName = executorType.Name;
            ExpectedArgName = expectedArgType.Name;
            ReceivedArg = arg?.ToString();
        }
    }
}