using SD.Domain.ObjectValues;
using System;

namespace SD.Domain.Entities
{
    public class Lancamento
    {
        public int Id { get; set; }
        public int OrigemId { get; set; }
        public int DestinoId { get; set; }
        public Valor Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
