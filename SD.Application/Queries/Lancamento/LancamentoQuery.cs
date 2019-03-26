using SD.Domain.Interfaces.Services;
using SD.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace SD.Application.Queries.Lancamento
{
    public class LancamentoQuery : ILancamentoQuery
    {
        private readonly ILancamentoService _LancamentoService;

        public LancamentoQuery(ILancamentoService service)
        {
            _LancamentoService = service;
        }

        public IEnumerable<LancamentoModel> GetLancamentosByTransacao(Transacao transacao)
        {
            return _LancamentoService.GetByTransacao(transacao)
                .Select(x => new LancamentoModel
                {
                    Transacao = x.Transacao,
                    ContaId = x.ContaId,
                    Data = x.Data.ToString("dd/MM/yyyy HH:mm:ss"),
                    Tipo = x.Tipo.ToString(),
                    Valor = x.Valor
                });
        }
    }
}
