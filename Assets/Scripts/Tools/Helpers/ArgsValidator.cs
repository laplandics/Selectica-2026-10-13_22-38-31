using System;

namespace Selectica
{
    public class ArgsValidator
    {
        private readonly Type _senderType;
        private readonly object[] _args;

        public ArgsValidator(Type senderType, object[] args)
        {
            _senderType = senderType;
            _args = args;
        }
        
        public T ValidateAt<T>(int index)
        {
            if (_args == null || _args.Length <= index)
            {
                throw new ExecuteException(_senderType, typeof(T), "null");
            }

            if (_args[index] is not T tArg)
            {
                throw new ExecuteException(_senderType, typeof(T), _args[index].GetType().Name);
            }
            
            return tArg;
        }
    }
}