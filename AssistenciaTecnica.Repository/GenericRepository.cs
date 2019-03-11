using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaTecnica.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        public AssistenciaTecnicaContext _context { get; }

        public GenericRepository(AssistenciaTecnicaContext context)
        {
            _context = context;
        }
        
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T[]> GetAllAsync()
        {
            IQueryable<T> query = _context.Set<T>(); //.AsQueryable();
            return await query.ToArrayAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public async Task<T[]> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate); //.AsQueryable();
            return await query.ToArrayAsync();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
             _context.Update(entity);
        }

        public void Delete(T entity)
        {
             _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
             return (await _context.SaveChangesAsync()) > 0; // Se maior que zero (salvou alguma informação de alguma entidade alterada), retorna true
        }
        
    }
}