using SD.Domain.Enums;
using SD.Domain.ValueObject;
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
        }

        public int Id { get; set; }
        public int ContaId { get; set; }
        public TipoLancamento Tipo { get; set; }
        public Valor Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
