using SD.Domain.Enums;
using SD.Domain.ValueObject;
using SD.Domain.ValueObjects;
using System;

namespace SD.Domain.Entities
{
    public class Lancamento
    {
        public Lancamento(TipoLancamento tipo, int contaId, decimal valor)
        {
            Tipo = tipo;
            ContaId = contaId;
            Valor = new Valor(valor);
            Data = DateTime.Now;
            Transacao = new Transacao();
        }

        public int Id { get; set; }
        public Guid Transacao { get; set; }
        public int ContaId { get; set; }
        public TipoLancamento Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public void LinkarTransacao(Transacao transacao) => Transacao = new Transacao(transacao);
    }

    public static class LancamentoBuilder
    {
        public static Lancamento NovoDebito(this Lancamento lancamento, ContaCorrente conta, Valor valor)
        {
            lancamento = new Lancamento(TipoLancamento.Debito, conta.Id, valor);
            return lancamento;
        }

        public static Lancamento AtualizaTransacao(this Lancamento lancamento,Valor valor)
        {
            lancamento.LinkarTransacao(new Transacao());
            return lancamento;
        }
    }
}
