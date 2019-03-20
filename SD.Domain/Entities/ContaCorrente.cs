using SD.Domain.ValueObject;
using System;

namespace SD.Domain.Entities
{
    public class ContaCorrente
    {
        private Random random = new Random();

        public ContaCorrente(int clienteId, decimal saldo = 0)
        {
            ClienteId = clienteId;
            Saldo = (Valor)saldo;
            Agencia = 2019;
            Numero = random.Next(1000, 9999);
        }

        public int Id { get; set; }
        public int ClienteId { get; private set; }
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public Valor Saldo { get; private set; }

        public void Debitar(Valor valor) => Saldo -= valor;

        public void Depositar(Valor valor) => Saldo += valor;
    }
}
