using SD.Domain.Enums;
using SD.Domain.ValueObject;
using SD.Domain.ValueObjects;
using System;

namespace SD.Domain.Entities
{
    public class Lancamento
    {
        public Lancamento()
        { }

        public Lancamento(TipoLancamento tipo, int contaId, Valor valor)
        {
            Tipo = tipo;
            ContaId = contaId;
            Valor = valor;
            Data = DateTime.Now;
            Transacao = new Transacao();
        }

        public int Id { get; set; }
        public Transacao Transacao { get; private set; }
        public int ContaId { get; private set; }
        public TipoLancamento Tipo { get; private set; }
        public Valor Valor { get; private set; }
        public DateTime Data { get; private set; }

        public void LinkarTransacao(Transacao transacao) => Transacao = new Transacao(transacao);
    }

    public static class LancamentoBuilder
    {
        public static Lancamento NovoDebito(ContaCorrente conta, Valor valor)
        {
            return new Lancamento(TipoLancamento.Debito, conta.Id, valor);
        }
    }
}
