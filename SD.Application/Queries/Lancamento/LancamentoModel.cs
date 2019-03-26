using System;

namespace SD.Application.Queries.Lancamento
{
    public class LancamentoModel
    {
        public Guid Transacao { get; set; }
        public string Tipo { get; set; }
        public int ContaId { get; set; }
        public decimal Valor { get; set; }
        public string Data { get; set; }
    }
}