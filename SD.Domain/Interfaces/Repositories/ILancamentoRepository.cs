using SD.Domain.Entities;
using SD.Domain.ValueObjects;
using System.Collections.Generic;

namespace SD.Domain.Interfaces.Repositories
{
    public interface ILancamentoRepository : IRepository<Lancamento>
    {
        IEnumerable<Lancamento> GetByTransacao(Transacao transacao);
    }
}
