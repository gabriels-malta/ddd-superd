using SD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace SD.Application.Queries.ContaCorrente
{
    public class ContaCorrenteQuery : IContaCorrenteQuery
    {
        private readonly IContaCorrenteService _ContaCorrenteService;

        public ContaCorrenteQuery(IContaCorrenteService contaCorrenteService)
        {
            _ContaCorrenteService = contaCorrenteService;
        }

        public IEnumerable<ContaCorrenteModel> GetAll()
        {
            return _ContaCorrenteService.GetAll()
                .Select(x => new ContaCorrenteModel
                {
                    Id = x.Id,
                    AgCc = $"Agencia: {x.Agencia} / Conta: {x.Numero}",
                    Saldo = x.Saldo.ToString()
                });
        }
    }
}
