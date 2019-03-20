using System;

namespace SD.Domain.Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException()
            : base("Saldo insuficiente para a operação.")
        { }
    }
}
