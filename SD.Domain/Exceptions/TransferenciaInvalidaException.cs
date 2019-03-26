using System;

namespace SD.Domain.Exceptions
{
    public class TransferenciaInvalidaException : Exception
    {
        public TransferenciaInvalidaException(string msg)
            : base(msg)
        { }
    }
}
