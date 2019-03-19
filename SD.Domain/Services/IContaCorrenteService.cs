using SD.Domain.ObjectValues;

namespace SD.Domain.Services
{
    public interface IContaCorrenteService
    {
        void Sacar(Valor valor);
        void Depositar(Valor valor);
    }
}
