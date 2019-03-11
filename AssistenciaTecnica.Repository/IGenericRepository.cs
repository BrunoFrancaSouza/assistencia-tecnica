using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AssistenciaTecnica.Repository
{
    public interface IGenericRepository<T> where T : class
    {
         
         IEnumerable<T> GetAll();
         Task<T[]> GetAllAsync();
         T GetById(int id);
         Task<T> GetByIdAsync(int id);
         IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate);
         Task<T[]> GetByAsync(Expression<Func<T, bool>> predicate);
         
        //  void Add<T>(T entity) where T : class;
         void Add(T entity);
        //  void Update<T>(T entity) where T : class;
         void Update(T entity);
        //  void Delete<T>(T entity) where T : class;
         void Delete(T entity);

         Task<bool> SaveChangesAsync();
    }
}