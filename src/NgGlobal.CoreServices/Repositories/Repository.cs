using Microsoft.EntityFrameworkCore;
using NgGlobal.ApplicationServices.Paging;
using NgGlobal.ApplicationShared.Paging;
using NgGlobal.CoreServices.Extensions;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseEntity.DB;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NgGlobal.CoreServices.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext = default;
        private DbSet<T> _entity = default;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = dbContext.Set<T>();
        }

        public async Task<int> CreateAndGetIdAsync(T item)
        {
            await _entity.AddAsync(item);
            await SaveAsync();
            return item.Id;
        }

        public async Task<bool> CreateAsync(T item)
        {
            await _entity.AddAsync(item);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _entity.FirstOrDefaultAsync(o => o.Id == id);
            _entity.Remove(item);
            return await SaveAsync();
        }

        public DbSet<T> Get()
        {
            return _entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync(List<Expression<Func<T, object>>> includes = null)
        {
            return await _entity.IncludeAll(includes).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(List<string> includes = null)
        {
            return await _entity.IncludeAll(includes).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes = null)
        {
            return await _entity.Where(filter)?.IncludeAll(includes).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, List<string> includes = null)
        {
            return await _entity.Where(filter)?.IncludeAll(includes).ToListAsync();
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes = null)
        {
            return await _entity?.IncludeAll(includes).FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter = null, List<string> includes = null)
        {
            return await _entity?.IncludeAll(includes).FirstOrDefaultAsync(filter);
        }

        public PagedList<T> ReadPagedData(PagingParams pagingParams)
        {
            var query = _entity.AsQueryable();
            return new PagedList<T>(query,pagingParams.PageNumber,pagingParams.PageSize);
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return (await _dbContext.SaveChangesAsync() >= 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, T item)
        {
            item.Id = id;
            _entity.Update(item);
            return await SaveAsync();
        }
    }
}
