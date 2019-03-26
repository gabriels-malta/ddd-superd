using SD.Domain.Entities;
using SD.Domain.Interfaces.Repositories;
using SD.Domain.ValueObjects;
using SD.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SD.Persistence.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly SDContext _db;

        public LancamentoRepository(SDContext context) => _db = context;

        public IEnumerable<Lancamento> GetAll()
        {
            return _db.Lancamentos.ToList();
        }

        public Lancamento GetById(int id)
        {
            return _db.Lancamentos.Find(id);
        }

        public IEnumerable<Lancamento> GetByTransacao(Transacao transacao)
        {
            return _db.Lancamentos.Where(x => x.Transacao == transacao);
        }

        public void Save(Lancamento entity)
        {
            _db.Lancamentos.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Lancamento entity)
        {
            _db.Lancamentos.Update(entity);
            _db.SaveChanges();
        }
    }
}
