using SD.Domain.Entities;
using SD.Domain.ValueObjects;
using System.Collections.Generic;

namespace SD.Domain.Interfaces.Services
{
    public interface ILancamentoService
    {
        Transacao RegistrarTransferencia(Lancamento origem, Lancamento destino);
        Transacao Registrar(Lancamento lancamento);
        IEnumerable<Lancamento> GetByTransacao(Transacao transacao);
    }
}
