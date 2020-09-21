using FootballСalendar.Entities;
using FootballСalendar.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Repo.Implement
{
    public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>
    {
        public DbContext Context { get; }
        public DbSet<TEntity> DbSet { get; }

        public BaseRepository(DbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> GetAll(bool notDeleted = true)
        {
            var query = DbSet.AsQueryable();
            if (notDeleted)
                query = query.Where(x => x.DateDelete != null);
            return DbSet.AsQueryable();
        }

        public TEntity GetById(TId id)
        {
            var item = DbSet.Find(id);

            if (item != null)
                return item;

            return null;
        }

        public TId Create(TEntity entity)
        {
            this.DbSet.Add(entity);
            this.Context.SaveChanges();
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();

        }

        public void Delete(TId id)
        {
            var item = DbSet.Find(id);

            if (item != null)
                DbSet.Remove(item);

            Context.SaveChanges();

        }

        public void Save()
        {
            Context.SaveChanges();
        }

        //public List<TEntity> GetPageList(int page, int pageSize = 2, Expression<Func<TEntity, bool>> filter = null)
        //{

        //    int pageNo = page - 1;
        //    var query = this.GetAll();
        //    if (filter != null)
        //        query = query.Where(filter);
        //    var list = query.OrderBy(x => x.Id)
        //        .Skip(pageNo * pageSize)
        //        .Take(pageSize)
        //        .ToList();
        //    return list;
        //}

        //public int GetCountItems()
        //{
        //    return this.GetAll().Count();
        //}
    }
}
