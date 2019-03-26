using SD.Domain.Entities;
using SD.Domain.Enums;
using SD.Domain.Interfaces.Services;
using SD.Domain.Validators;
using SD.Domain.ValueObject;

namespace SD.Application.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly ILancamentoService lancamentoService;

        public ContaCorrenteService(ILancamentoService service)
        {
            lancamentoService = service;
        }

        public void Depositar(ContaCorrente conta, Valor valor)
        {
            conta.Depositar(valor);
            lancamentoService.Registrar(new Lancamento(TipoLancamento.Credito, conta.Id, valor));
        }

        public void Sacar(ContaCorrente conta, Valor valor)
        {
            ContaCorrenteValidator.ExisteSaldoParaSaque(conta, valor);
            conta.Debitar(valor);
            lancamentoService.Registrar(new Lancamento(TipoLancamento.Debito, conta.Id, valor));
        }

        public void Transferir(ContaCorrente origem, ContaCorrente destino, Valor valor)
        {
            ContaCorrenteValidator.ExisteSaldoParaSaque(origem, valor);

            origem.Debitar(valor);
            destino.Depositar(valor);

            var lancamentoSaida = new Lancamento(TipoLancamento.Debito, origem.Id, valor);
            var lancamentoEntrada = new Lancamento(TipoLancamento.Credito, destino.Id, valor);

            lancamentoService.RegistrarTransferencia(lancamentoEntrada, lancamentoSaida);
        }
    }
}
