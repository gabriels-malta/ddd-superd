using SD.Domain.Entities;
using SD.Domain.Enums;
using SD.Domain.Exceptions;
using SD.Domain.Interfaces.Repositories;
using SD.Domain.Interfaces.Services;
using SD.Domain.Validators;
using SD.Domain.ValueObject;
using SD.Domain.ValueObjects;

namespace SD.Application.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository repository;
        private readonly ILancamentoService lancamentoService;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository, ILancamentoService service)
        {
            repository = contaCorrenteRepository;
            lancamentoService = service;
        }

        public void Depositar(ContaCorrente conta, Valor valor)
        {
            conta.Depositar(valor);
            lancamentoService.Registrar(new Lancamento(TipoLancamento.Credito, conta.Id, valor));
            repository.Update(conta);
        }

        public void Sacar(ContaCorrente conta, Valor valor)
        {
            ContaCorrenteValidator.ExisteSaldoParaSaque(conta, valor);
            conta.Debitar(valor);
            lancamentoService.Registrar(new Lancamento(TipoLancamento.Debito, conta.Id, valor));
            repository.Update(conta);
        }

        public void Transferir(ContaCorrente origem, ContaCorrente destino, Valor valor)
        {
            ContaCorrenteValidator.ExisteSaldoParaSaque(origem, valor);

            origem.Debitar(valor);
            var lancamentoSaida = new Lancamento(TipoLancamento.TransferenciaSaida, origem.Id, valor);
            Transacao transacaoSaida = lancamentoService.Registrar(lancamentoSaida);

            destino.Depositar(valor);
            var lancamentoEntrda = new Lancamento(TipoLancamento.TransferenciaEntrada, destino.Id, valor);
            lancamentoEntrda.LinkarTransacao(transacaoSaida);
            lancamentoService.Registrar(lancamentoEntrda);

            repository.Update(origem);
            repository.Update(destino);
        }
    }
}
