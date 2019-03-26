using SD.Domain.Interfaces.Services;
using SD.Domain.ValueObject;
using SD.Domain.ValueObjects;

namespace SD.Application.Commands.Transferencia
{
    public class TransferenciaCommand : ITransferenciaCommand
    {
        private readonly IContaCorrenteService _ContaCorrenteService;

        public TransferenciaCommand(IContaCorrenteService contaCorrenteService)
        {
            _ContaCorrenteService = contaCorrenteService;
        }

        public Transacao Transferir(TransferenciaModel transferencia)
        {
            var origem = _ContaCorrenteService.GetById(transferencia.origem);
            var destino = _ContaCorrenteService.GetById(transferencia.destino);
            return _ContaCorrenteService.Transferir(origem, destino, new Valor(transferencia.valor));
        }
    }
}
