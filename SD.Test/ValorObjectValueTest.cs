using SD.Domain.ValueObject;
using Xunit;

namespace SD.Test
{
    public class ValorObjectValueTest
    {
        [Fact]
        public void ConversaoExplicita()
        {
            var valor = (Valor)28;

            Assert.Equal("R$ 28,00", valor.ToString());
        }

        [Fact]
        public void AssertEquals()
        {
            Valor v = new Valor(9);
            Assert.True(v.Equals(9));
        }
    }
}
