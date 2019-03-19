using SD.Domain.ObjectValues;

namespace SD.Domain.Entities
{
    public class ContaCorrente
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public Valor Saldo { get; set; }
    }
}
