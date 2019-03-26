using System.Collections.Generic;

namespace SD.Application.Queries.ContaCorrente
{
    public    interface IContaCorrenteQuery
    {
        IEnumerable<ContaCorrenteModel> GetAll();
    }
}
