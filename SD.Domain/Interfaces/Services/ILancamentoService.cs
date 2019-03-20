using SD.Domain.Entities;

namespace SD.Domain.Interfaces.Services
{
    public interface ILancamentoService
    {
        void Registrar(Lancamento lancamento);
    }
}
