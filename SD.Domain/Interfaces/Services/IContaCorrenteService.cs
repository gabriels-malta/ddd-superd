using SD.Domain.Entities;
using SD.Domain.ValueObject;

namespace SD.Domain.Interfaces.Services
{
    public interface IContaCorrenteService
    {
        void Sacar(ContaCorrente conta, Valor valor);
        void Depositar(ContaCorrente conta, Valor valor);
    }
}
