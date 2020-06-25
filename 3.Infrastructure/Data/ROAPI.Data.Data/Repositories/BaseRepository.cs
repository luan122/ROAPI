using Microsoft.EntityFrameworkCore;
using ROAPI.Infrastructure.Data.Data.Contexts;
using ROAPI.Infrastructure.Data.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROAPI.Infrastructure.Data.Data.Repositories
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class
        where TContext: DbContext
    {
        protected readonly TContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(TContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual async Task<TEntity> Add(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            return obj;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            var obj = await DbSet.FindAsync(id);
            return obj;
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity Update(TEntity obj)
        {
            DbSet.Update(obj);
            return obj;
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
