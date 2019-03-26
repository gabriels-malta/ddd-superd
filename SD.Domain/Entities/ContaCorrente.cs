using SD.Domain.ValueObject;
using System;

namespace SD.Domain.Entities
{
    public class ContaCorrente
    {
        private Random random = new Random();

        public ContaCorrente() { }

        public ContaCorrente(int clienteId, decimal saldo = 0)
        {
            ClienteId = clienteId;
            Saldo = saldo;
            Agencia = 2019;
            Numero = random.Next(1000, 9999);
        }

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; set; }

        public void Debitar(Valor valor) => Saldo -= valor;

        public void Depositar(Valor valor) => Saldo += valor;
    }
}
