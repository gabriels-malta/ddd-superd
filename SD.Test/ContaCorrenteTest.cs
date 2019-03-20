using SD.Application.Services;
using SD.Domain.Entities;
using SD.Domain.Exceptions;
using SD.Domain.Interfaces.Services;
using SD.Domain.ValueObject;
using Xunit;

namespace SD.Test
{
    public class ContaCorrenteTest
    {
        private IContaCorrenteService ContaCorrenteService;
        private ContaCorrente conta;

        [Fact]
        public void CriarNovaConta()
        {
            conta = new ContaCorrente(9, 100);

            Assert.True(conta.Agencia == 2019);
            Assert.True(conta.Numero >= 1000 && conta.Numero <= 9999);
            Assert.True(conta.PossuiSaldoParaSacar((Valor)99));
        }

        [Fact]
        public void MustThrowSaldoInsuficienteException()
        {
            ContaCorrenteService = new ContaCorrenteService();
            conta = new ContaCorrente(9, 100);

            Assert.Throws<SaldoInsuficienteException>(() => ContaCorrenteService.Sacar(conta, (Valor)150));
        }
    }
}
