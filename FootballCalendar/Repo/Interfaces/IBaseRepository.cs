using FootballСalendar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballСalendar.Repo.Interfaces
{
    public interface IBaseRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>
    {
        IQueryable<TEntity> GetAll(bool notDeleted = true);
        //List<TEntity> GetPageList(int page, int pageSize, Expression<Func<TEntity, bool>> filter = null);
        //int GetCountItems();
        TEntity GetById(TId id);
        TId Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TId id);
        void Save();
    }

}
