using Core.Repositories.Base;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected  ApplicationDbContext context { get; set; }
        protected DbSet<T> dbSet { get; set; }

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();

        }

   
        public virtual async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync(); 
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id); 
        }

        public virtual async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
