using System;

namespace SD.Domain.Exceptions
{
    public class ContaCorrenteException : Exception
    {
        public ContaCorrenteException(string msg)
            : base(msg) { }
    }
}
