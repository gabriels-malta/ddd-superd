using SD.Domain.Entities;

namespace SD.Domain.Interfaces.Repositories
{
    public interface IContaCorrenteRepository : IRepository<ContaCorrente>
    {
        ContaCorrente GetByCliente(int clienteId);        
    }
}
