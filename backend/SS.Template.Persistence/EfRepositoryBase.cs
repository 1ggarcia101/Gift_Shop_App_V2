using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SS.Template.Core.Persistence;

namespace SS.Template.Persistence
{
    public abstract class EfRepositoryBase : IRepositoryBase
    {
        private readonly bool _isReadOnly;
        protected DbContext Context { get; }

        protected EfRepositoryBase(DbContext context, bool isReadOnly)
        {
            _isReadOnly = isReadOnly;
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected virtual DbSet<T> Set<T>()
            where T : class
        {
            return Context.Set<T>();
        }

        public virtual IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate, IEnumerable<Expression<Func<T, object>>> includes)
            where T : class
        {
            var query = (IQueryable<T>)Set<T>();

            if (_isReadOnly)
            {
                query = query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return WithIncludes(query, includes);
        }

        public virtual T Get<T, TKey>(TKey id)
            where T : class
            where TKey : IEquatable<TKey>
        {
            return Set<T>().Find(id);
        }

        public IQueryable<T> Include<T, TProperty>(IQueryable<T> query,
            Expression<Func<T, TProperty>> navigationPropertyPath)
            where T : class
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (navigationPropertyPath == null)
            {
                throw new ArgumentNullException(nameof(navigationPropertyPath));
            }

            return query.Include(navigationPropertyPath);
        }

        #region Async methods
        public T First<T>(IQueryable<T> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.FirstOrDefault();
        }
        public T First<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.FirstOrDefault(predicate);
        }
        public Task<T> FirstAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.FirstOrDefaultAsync(cancellationToken);
        }

        public Task<T> SingleAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.SingleOrDefaultAsync(cancellationToken);
        }

        public Task<bool> AnyAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.AnyAsync(cancellationToken);
        }

        public Task<bool> AllAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return query.AllAsync(predicate, cancellationToken);
        }

        public Task ForEachAsync<T>(IQueryable<T> query, Action<T> action, CancellationToken cancellationToken = default)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return query.ForEachAsync(action, cancellationToken);
        }

        public Task<int> CountAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.CountAsync(cancellationToken);
        }

        public Task<List<T>> ListAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.ToListAsync(cancellationToken);
        }

        private static IQueryable<T> WithIncludes<T>(IQueryable<T> query, IEnumerable<Expression<Func<T, object>>> includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        #endregion Async methods
    }
}
