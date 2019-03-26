using SD.Domain.Entities;
using SD.Domain.ValueObject;
using SD.Domain.ValueObjects;
using System.Collections.Generic;

namespace SD.Domain.Interfaces.Services
{
    public interface IContaCorrenteService
    {
        ContaCorrente GetById(int id);
        IEnumerable<ContaCorrente> GetAll();
        Transacao Sacar(ContaCorrente conta, Valor valor);
        Transacao Depositar(ContaCorrente conta, Valor valor);
        Transacao Transferir(ContaCorrente origem, ContaCorrente destino, Valor valor);
    }
}
