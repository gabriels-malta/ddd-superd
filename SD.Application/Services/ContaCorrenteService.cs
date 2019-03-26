using SD.Domain.Entities;
using SD.Domain.Enums;
using SD.Domain.Exceptions;
using SD.Domain.Interfaces.Services;
using SD.Domain.Validators;
using SD.Domain.ValueObject;
using SD.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace SD.Application.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly ILancamentoService lancamentoService;

        public ContaCorrenteService(ILancamentoService service)
        {
            lancamentoService = service;
        }

        public Transacao Depositar(ContaCorrente conta, Valor valor)
        {
            conta.Depositar(valor);
            return lancamentoService.Registrar(new Lancamento(TipoLancamento.Credito, conta.Id, valor));
        }

        public IEnumerable<ContaCorrente> GetAll()
        {
            return new List<ContaCorrente>()
            {
                new ContaCorrente(19, 175.5M) { Id = 1 },
                new ContaCorrente(37, 789.3M) { Id = 2 }
            };
        }

        public ContaCorrente GetById(int id)
        {
            var conta = GetAll().FirstOrDefault(x => x.Id == id);
            if (conta == null)
                throw new ContaCorrenteException($"Conta (id: {id}) não encontrada.");

            return conta;
        }

        public Transacao Sacar(ContaCorrente conta, Valor valor)
        {
            ContaCorrenteValidator.ExisteSaldoParaSaque(conta, valor);
            conta.Debitar(valor);
            return lancamentoService.Registrar(new Lancamento(TipoLancamento.Debito, conta.Id, valor));
        }

        public Transacao Transferir(ContaCorrente origem, ContaCorrente destino, Valor valor)
        {
            ContaCorrenteValidator.ExisteSaldoParaSaque(origem, valor);

            origem.Debitar(valor);
            destino.Depositar(valor);

            var lancamentoSaida = new Lancamento(TipoLancamento.Debito, origem.Id, valor);
            var lancamentoEntrada = new Lancamento(TipoLancamento.Credito, destino.Id, valor);

            return lancamentoService.RegistrarTransferencia(lancamentoEntrada, lancamentoSaida);
        }
    }
}
