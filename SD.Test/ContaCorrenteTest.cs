using Microsoft.EntityFrameworkCore;
using SD.Application.Services;
using SD.Domain.Entities;
using SD.Domain.Exceptions;
using SD.Domain.Interfaces.Repositories;
using SD.Domain.Interfaces.Services;
using SD.Domain.ValueObject;
using SD.Persistence.Context;
using SD.Persistence.Repositories;
using Xunit;

namespace SD.Test
{
    public class ContaCorrenteTest
    {
        private ILancamentoRepository GetLancamentoRepository()
        {
            var options = new DbContextOptionsBuilder<SDContext>()
                .UseInMemoryDatabase(databaseName: "Test_DB")
                .Options;
            SDContext context = new SDContext(options);
            return new LancamentoRepository(context);
        }

        private IContaCorrenteService _ContaCorrenteService;
        private ContaCorrente Conta;
        private Valor Valor;

        public ContaCorrenteTest()
        {
            _ContaCorrenteService = new ContaCorrenteService(new LancamentoService(GetLancamentoRepository()));
        }

        [Fact]
        public void Deposito()
        {
            Conta = new ContaCorrente(9, 100);
            Valor = new Valor(50);
            _ContaCorrenteService.Depositar(Conta, Valor);
            Assert.True(Conta.Saldo == 150);
        }

        [Fact]
        public void Saque()
        {
            Conta = new ContaCorrente(9, 100);
            Valor = new Valor(50);
            _ContaCorrenteService.Sacar(Conta, Valor);
            Assert.True(Conta.Saldo == 50);
        }

        [Fact]
        public void Transferencia()
        {
            var origem = new ContaCorrente(7, 100) { Id = 7 };
            var destino = new ContaCorrente(9, 32) { Id = 19 };
            _ContaCorrenteService.Transferir(origem, destino, (Valor)68);
            Assert.True(origem.Saldo == (100 - 68));
        }

        [Fact]
        public void MustThrowSaldoInsuficienteException()
        {
            Conta = new ContaCorrente(9, 100);
            Valor = new Valor(150);
            Assert.Throws<SaldoInsuficienteException>(() => _ContaCorrenteService.Sacar(Conta, Valor));
        }

        [Fact]
        public void MustThrowContaCorrenteException()
        {
            Assert.Throws<ContaCorrenteException>(() => _ContaCorrenteService.GetById(7));
        }
    }
}
