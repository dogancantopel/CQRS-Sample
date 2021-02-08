using CQRSApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CQRSApi.Repository
{
    public interface IBaseRepository<T> where T : BaseClass
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllList(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task<bool> AddRange(IEnumerable<T> entities);
        Task<T> Remove(int id);
        Task<T> Update(int id, T entity);
    }
}
