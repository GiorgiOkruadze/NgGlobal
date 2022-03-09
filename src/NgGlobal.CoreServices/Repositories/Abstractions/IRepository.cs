using Microsoft.EntityFrameworkCore;
using NgGlobal.ApplicationServices.Paging;
using NgGlobal.ApplicationShared.Paging;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NgGlobal.CoreServices.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> CreateAsync(T item);
        Task<int> CreateAndGetIdAsync(T item);
        DbSet<T> Get();
        Task<bool> UpdateAsync(int id, T item);
        Task<bool> DeleteAsync(int id);
        PagedList<T> ReadPagedData(PagingParams pagingParams, List<string> includes = null);
        Task<IEnumerable<T>> GetAllAsync(List<Expression<Func<T, object>>> includes);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes=null);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes=null);
        Task<IEnumerable<T>> GetAllAsync(List<string> includes);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, List<string> includes = null);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter = null, List<string> includes = null);
        IQueryable<T> GetAsQuerable(List<string> includes = null);
        Task<bool> SaveAsync();
    }
}
