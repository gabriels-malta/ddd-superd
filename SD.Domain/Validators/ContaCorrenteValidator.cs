using SD.Domain.Entities;
using SD.Domain.Exceptions;
using SD.Domain.ValueObject;

namespace SD.Domain.Validators
{
    public abstract class ContaCorrenteValidator
    {
        public static void VerificaSaldoAposSaque(ContaCorrente conta, Valor valor)
        {
            var saldo = conta.Saldo - valor;

            if (saldo <= 0)
                throw new SaldoInsuficienteException();
        }
    }
}
