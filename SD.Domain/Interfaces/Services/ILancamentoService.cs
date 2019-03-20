using SD.Domain.Entities;
using SD.Domain.ValueObjects;

namespace SD.Domain.Interfaces.Services
{
    public interface ILancamentoService
    {
        Transacao Registrar(Lancamento lancamento);
    }
}
