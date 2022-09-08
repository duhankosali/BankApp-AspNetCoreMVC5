using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Entities;
using Dk.BankApp.Web.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Dk.BankApp.Web.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new() // Generic T bir class olmalı ve newlenebilmeli (static vs. olamaz)
    {
        private readonly BankContext _context;
        public Repository(BankContext context)
        {
            _context = context;
        }

        public void Create (T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges(); 
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(object Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public IQueryable<T> GetQueryable()
        {
            //throw new System.NotImplementedException();
            return _context.Set<T>().AsQueryable();
        }
    }

    
}
