using SD.Domain.Entities;
using SD.Domain.ValueObject;
using SD.Domain.ValueObjects;

namespace SD.Domain.Interfaces.Services
{
    public interface ILancamentoService
    {
        Transacao RegistrarTransferencia(Lancamento origem, Lancamento destino);
        Transacao Registrar(Lancamento lancamento);
    }
}
