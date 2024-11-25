using HR.LeaveManagement.Application.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LeaveManagementDbContext _dbContext;

        public GenericRepository(LeaveManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

         public async Task Delete(T entity)
            {
                 _dbContext.Set<T>().Remove(entity);
                 await _dbContext.SaveChangesAsync();
            }

         public async Task<bool> Exist(int id)
        {
            var entity = Get(id);
            return entity != null;
        }

         public async Task<T> Get(int id)
         {
             return await _dbContext.Set<T>().FindAsync(id);
         }

         public async Task<IReadOnlyList<T>> GetAll()
         {
             var result = await _dbContext.Set<T>().ToListAsync();
             return result;
         }

         public async Task Update(T entity)
         {
             _dbContext.Entry(entity).State = EntityState.Modified;
             await _dbContext.SaveChangesAsync();
         }
    }
}
