using SD.Domain.Interfaces.Services;
using SD.Domain.ValueObject;

namespace SD.Application.Commands
{
    public class TransferenciaCommand : ITransferenciaCommand
    {
        private readonly IContaCorrenteService _ContaCorrenteService;

        public TransferenciaCommand(IContaCorrenteService contaCorrenteService)
        {
            _ContaCorrenteService = contaCorrenteService;
        }

        public void Transferir(TransferenciaModel transferencia)
        {
            var origem = _ContaCorrenteService.GetById(transferencia.origem);
            var destino = _ContaCorrenteService.GetById(transferencia.destino);
            _ContaCorrenteService.Transferir(origem, destino, new Valor(transferencia.valor));
        }
    }
}
