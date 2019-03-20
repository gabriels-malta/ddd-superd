using System;

namespace SD.Domain.ValueObject
{
    public class Valor
    {
        private decimal _quantia;

        #region Constructors
        public Valor(object quantia) => _quantia = Convert.ToDecimal(quantia);
        #endregion

        public static implicit operator decimal(Valor valor) => valor._quantia;

        public static explicit operator Valor(decimal? valor) => new Valor(valor);

        public override string ToString()
        {
            return $"R$ {_quantia.ToString("N2")}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Valor valor = new Valor(obj);

            return _quantia == valor._quantia;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
