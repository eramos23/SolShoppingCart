using Microsoft.EntityFrameworkCore;
using Ramos.ShoppingCart.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Shared.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TContext DbContext<TContext>() where TContext : DbContext
        {
            return Context as TContext;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetById(string id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllOrder(Func<TEntity, object> order, ListSortDirection sortDirection)
        {
            Func<TEntity, object> order2 = order;
            if (sortDirection == ListSortDirection.Ascending)
            {
                return await (from c in Context.Set<TEntity>()
                              orderby order2
                              select c).ToListAsync().ConfigureAwait(continueOnCapturedContext: false);
            }

            return await (from c in Context.Set<TEntity>()
                          orderby order2 descending
                          select c).ToListAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<IEnumerable<TEntity>> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> SelectIncludes(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            return await queryable.ToListAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<IEnumerable<TObject>> SelectObjectWithIncludes<TObject>(Expression<Func<TEntity, TObject>> select, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            return await queryable.Select(select).ToListAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<IEnumerable<TObject>> SelectObjectWithIncludes<TKey, TObject>(Expression<Func<TEntity, TObject>> select, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> order, ListSortDirection sortDirection, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            if (order != null)
            {
                queryable = ((sortDirection != ListSortDirection.Descending) ? queryable.OrderBy(order) : queryable.OrderByDescending(order));
            }

            return await queryable.Select(select).ToListAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<int> Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<TEntity> AddAndReturn(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> AddRange(IEnumerable<TEntity> entityList)
        {
            Context.Set<TEntity>().AddRange(entityList);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public async Task<int> UpdateEntity(TEntity entitySource, TEntity entityDestiny)
        {
            Context.Entry(entityDestiny).CurrentValues.SetValues(entitySource);
            return await Context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateKeyAndReturn(TEntity entity, object key)
        {
            if (entity == null)
            {
                return null;
            }

            TEntity exist = await Context.Set<TEntity>().FindAsync(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                await Context.SaveChangesAsync();
            }

            return exist;
        }

        public async Task<int> Delete(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> DeleteAndReturn(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> DeleteRange(IEnumerable<TEntity> entityList)
        {
            List<TEntity> list = entityList.ToList();
            foreach (TEntity item in list)
            {
                Context.Set<TEntity>().Attach(item);
            }

            Context.Set<TEntity>().RemoveRange(list);
            return await Context.SaveChangesAsync();
        }

        public void Attach(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return Context.Set<TEntity>();
        }

        public IQueryable<TEntity> FindByQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<int> Count()
        {
            return await Context.Set<TEntity>().CountAsync();
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            return await queryable.FirstOrDefaultAsync();
        }

        public async Task<TObject> FirstOrDefaultSelect<TObject>(Expression<Func<TEntity, TObject>> select, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            return await queryable.Select(select).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> SelectIncludesOrder(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order, params Expression<Func<TEntity, object>>[] includes)
        {
            Expression<Func<TEntity, object>> order2 = order;
            IQueryable<TEntity> queryable = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            if (order2 != null)
            {
                queryable.OrderBy((TEntity c) => order2);
            }

            return await queryable.ToListAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<int> CountIncludes(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            return await queryable.CountAsync();
        }

        public async Task<IEnumerable<TEntity>> SelectIncludesWithTake(Expression<Func<TEntity, bool>> predicate, int take, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            return await queryable.Take(take).ToListAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<IEnumerable<TEntity>> SelectIncludesWithPagination(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order, ListSortDirection sortDirection, int page, int pageSize, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            int count = (((page <= 0) ? 1 : page) - 1) * pageSize;
            if (sortDirection == ListSortDirection.Descending)
            {
                return await queryable.OrderByDescending(order).Skip(count).Take(pageSize)
                    .ToListAsync()
                    .ConfigureAwait(continueOnCapturedContext: false);
            }

            return await queryable.OrderBy(order).Skip(count).Take(pageSize)
                .ToListAsync()
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<TEntity> FirstOrDefaultOrder(Expression<Func<TEntity, bool>> predicate, Func<TEntity, object> order, ListSortDirection sortDirection, params Expression<Func<TEntity, object>>[] includes)
        {
            Func<TEntity, object> order2 = order;
            List<TEntity> source = null;
            IQueryable<TEntity> queryable = Context.Set<TEntity>().Where(predicate);
            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            if (order2 != null)
            {
                source = ((sortDirection != 0) ? (await queryable.OrderByDescending((TEntity c) => order2).ToListAsync().ConfigureAwait(continueOnCapturedContext: false)) : (await queryable.OrderBy((TEntity c) => order2).ToListAsync().ConfigureAwait(continueOnCapturedContext: false)));
            }

            return source.FirstOrDefault();
        }

        public async Task<IEnumerable<TEntity>> SelectListExpression(List<Expression<Func<TEntity, bool>>> predicates)
        {
            IQueryable<TEntity> source = from a in Context.Set<TEntity>().AsNoTracking()
                                         where true
                                         select a;
            foreach (Expression<Func<TEntity, bool>> predicate in predicates)
            {
                source = source.Where(predicate);
            }

            return await source.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> SelectIncludesWithListExpression(List<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> queryable = from a in Context.Set<TEntity>().AsNoTracking()
                                            where true
                                            select a;
            foreach (Expression<Func<TEntity, bool>> predicate in predicates)
            {
                queryable = queryable.Where(predicate);
            }

            if (includes != null)
            {
                queryable = includes.Aggregate(queryable, (IQueryable<TEntity> c, Expression<Func<TEntity, object>> include) => c.Include(include));
            }

            return await queryable.ToListAsync().ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
