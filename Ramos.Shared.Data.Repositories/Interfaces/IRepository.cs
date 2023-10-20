using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ramos.ShoppingCart.Shared.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);

        Task<TEntity> GetById(string id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetAllOrder(Func<TEntity, object> order, ListSortDirection sortDirection);

        Task<IEnumerable<TEntity>> Select(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> SelectListExpression(List<Expression<Func<TEntity, bool>>> predicates);

        Task<IEnumerable<TEntity>> SelectIncludes(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> SelectIncludesWithTake(Expression<Func<TEntity, bool>> predicate, int take, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> SelectIncludesWithPagination(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order, ListSortDirection sortDirection, int page, int pageSize, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> SelectIncludesOrder(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TObject>> SelectObjectWithIncludes<TObject>(Expression<Func<TEntity, TObject>> select, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TObject>> SelectObjectWithIncludes<TKey, TObject>(Expression<Func<TEntity, TObject>> select, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> order, ListSortDirection sortDirection, params Expression<Func<TEntity, object>>[] includes);

        Task<int> Add(TEntity entity);

        Task<TEntity> AddAndReturn(TEntity entity);

        Task<int> AddRange(IEnumerable<TEntity> entityList);

        Task<int> Update(TEntity entity);

        Task<int> UpdateEntity(TEntity entitySource, TEntity entityDestiny);

        Task<TEntity> UpdateKeyAndReturn(TEntity entity, object key);

        Task<int> Delete(TEntity entity);

        Task<int> DeleteAndReturn(TEntity entity);

        Task<int> DeleteRange(IEnumerable<TEntity> entityList);

        void Attach(TEntity entity);

        IQueryable<TEntity> GetQueryable();

        Task<int> Count();

        Task<int> CountIncludes(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<TObject> FirstOrDefaultSelect<TObject>(Expression<Func<TEntity, TObject>> select, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> FirstOrDefaultOrder(Expression<Func<TEntity, bool>> predicate, Func<TEntity, object> order, ListSortDirection sortDirection, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> SelectIncludesWithListExpression(List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includes);
    }
}
