﻿using System.Collections.Generic;

namespace SD.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        void Save(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
