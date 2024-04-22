using DataMatrix_TestApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace DataMatrix_TestApp.Repositories
{
    public class GenericRepository<T> where T: class
    {
        protected DbContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

  
        public virtual async Task<IEnumerable<T>> GetPaged(int page = 1, int perPage = 10)
        {
            var skipped = (page - 1) * perPage;
            IQueryable<T> query = dbSet;
            var set = query.Skip(skipped).Take(perPage);
            return set;
        }

        public virtual async Task<T?> GetById(object id)
        {
            var result = await dbSet.FindAsync(id);
            return result is null ? null : result;
        }

        public virtual async Task<T?> Insert(T entity)
        {
            try
            {
                var result = await dbSet.AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public virtual async Task<string> Delete(object id)
        {
            T entityToDelete = await dbSet.FindAsync(id);
            if(entityToDelete is null)
                return null;
            
            await Delete(entityToDelete);
            return "Success";
        }
        public virtual async Task Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            await context.SaveChangesAsync();
        }
        public virtual async Task<T?> Update(T entityToUpdate)
        {
            try
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entityToUpdate;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
