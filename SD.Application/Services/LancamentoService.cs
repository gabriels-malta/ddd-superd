using SD.Domain.Entities;
using SD.Domain.Interfaces.Services;
using SD.Domain.ValueObjects;

namespace SD.Application.Services
{
    public class LancamentoService : ILancamentoService
    {
        public Transacao Registrar(Lancamento lancamento)
        {
            //TODO: Repository.Save(lancamento)
            return new Transacao(lancamento.Transacao);
        }
    }
}
