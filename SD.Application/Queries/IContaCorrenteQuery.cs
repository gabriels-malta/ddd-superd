using System.Collections.Generic;

namespace SD.Application.Queries
{
    public    interface IContaCorrenteQuery
    {
        IEnumerable<ContaCorrenteModel> GetAll();
    }
}
