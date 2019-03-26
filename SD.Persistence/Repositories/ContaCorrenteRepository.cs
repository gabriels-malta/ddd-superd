using SD.Domain.Entities;
using SD.Domain.Interfaces.Repositories;
using SD.Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace SD.Persistence.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly SDContext _db;

        public ContaCorrenteRepository(SDContext context)
        {
            _db = context;
        }

        public IEnumerable<ContaCorrente> GetAll()
        {
            return _db.ContaCorrente.ToList();
        }

        public ContaCorrente GetByCliente(int clienteId)
        {
            return _db.ContaCorrente.SingleOrDefault(x => x.ClienteId == clienteId);
        }

        public ContaCorrente GetById(int id)
        {
            return _db.ContaCorrente.Find(id);
        }

        public void Save(ContaCorrente entity)
        {
            _db.ContaCorrente.Add(entity);
            _db.SaveChanges();
        }

        public void Update(ContaCorrente entity)
        {
            _db.ContaCorrente.Update(entity);
            _db.SaveChanges();
        }
    }
}
