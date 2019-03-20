using SD.Domain.Entities;
using SD.Domain.Enums;
using SD.Domain.Exceptions;
using SD.Domain.Interfaces.Services;
using SD.Domain.ValueObject;

namespace SD.Application.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly ILancamentoService lancamentoService;
        public ContaCorrenteService()
        {

        }
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
            if (!conta.PossuiSaldoParaSacar(valor))
            {
                throw new SaldoInsuficienteException();
            }
            conta.Debitar(valor);
            lancamentoService.Registrar(new Lancamento(TipoLancamento.Debito, conta.Id, valor));
        }
    }
}
