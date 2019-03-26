using SD.Domain.Enums;
using SD.Domain.Validators;
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

            LancamentoValidator.ValidaValor(Valor);
        }

        public int Id { get; set; }
        public Guid Transacao { get; set; }
        public int ContaId { get; set; }
        public TipoLancamento Tipo { get; set; }
        public Valor Valor { get; set; }
        public DateTime Data { get; set; }

        public void LinkarTransacao(Guid transacao) => Transacao = new Transacao(transacao);
    }
}
