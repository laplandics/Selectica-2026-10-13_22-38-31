using System;

namespace Selectica
{
    public class HandlerArgumentException : Exception
    {
        public string SenderName { get; }
        public string ExpectedArgTypeName { get; }
        public object ReceivedArg { get; }

        public HandlerArgumentException(IHandler sender, Type expectedArgType, object arg) :
            base($"{sender.GetType().Name}: Invalid argument: {arg}! {expectedArgType.Name} expected")
        {
            SenderName = sender.GetType().Name;
            ExpectedArgTypeName = expectedArgType.Name;
            ReceivedArg = arg;
        }
    }
}