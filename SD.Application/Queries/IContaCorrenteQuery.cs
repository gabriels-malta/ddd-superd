using System;
using System.Collections.Generic;
using System.Text;

namespace SD.Application.Queries
{
public    interface IContaCorrenteQuery
    {
        IEnumerable<ContaCorrenteModel> GetAll();
    }
}
