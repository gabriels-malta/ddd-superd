namespace SD.Domain.ObjectValues
{
    public class Valor
    {
        private decimal _quantia;

        public Valor(decimal? quantia)
        {
            _quantia = quantia ?? 0;
        }

        public static implicit operator decimal(Valor valor) => valor._quantia;

        public static explicit operator Valor(decimal? valor) => new Valor(valor);

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            Valor valor = (Valor)obj;

            return _quantia == valor._quantia;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
