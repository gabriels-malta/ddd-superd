using SD.Domain.ValueObject;
using System;

namespace SD.Domain.Entities
{
    public class ContaCorrente
    {
        Random random = new Random();

        public ContaCorrente(int clienteId, decimal saldo = 0)
        {
            ClienteId = clienteId;
            Saldo = new Valor(saldo);
            Agencia = 2019;
            Numero = random.Next(1000, 9999);
        }

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public Valor Saldo { get; set; }

        public void Debitar(Valor valor) => Saldo -= valor;

        public void Depositar(Valor valor) => Saldo += valor;
    }
}
