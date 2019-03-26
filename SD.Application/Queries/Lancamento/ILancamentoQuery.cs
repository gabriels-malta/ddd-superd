using SD.Domain.ValueObjects;
using System.Collections.Generic;

namespace SD.Application.Queries.Lancamento
{
    public interface ILancamentoQuery
    {
        IEnumerable<LancamentoModel> GetLancamentosByTransacao(Transacao transacao);
    }
}
