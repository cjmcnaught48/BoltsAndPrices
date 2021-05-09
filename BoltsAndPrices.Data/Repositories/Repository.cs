using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BoltsAndPrices.Data.Domain;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;


namespace BoltsAndPrices.Data.Repositories
{
    public class Repository<T> where T : class
    {
        protected BoltsAndPricesContext _context;

        /// <summary>
        /// The set that represents the current entity
        /// </summary>
        protected DbSet<T> _dbSet;

        public Repository(BoltsAndPricesContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Get all objects from database
        /// </summary>
        /// <param name="orderBy">The order in which the objects should be sorted, otherwise null</param>
        public virtual IQueryable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            return GetWhere(null, orderBy);
        }

        /// <summary>
        /// Get objects from database using an expression tree filter and sorting
        /// </summary>
        /// <param name="filter">The filter by which the objects are included, otherwise null</param>
        /// <param name="orderBy">The order in which the objects should be sorted, otherwise null</param>
        /// <param name="noTracking">True if the returned objects should not be tracked by the underlying DbContext</param>
        public virtual IQueryable<T> GetWhere(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool noTracking = false)
        {
            IQueryable<T> query;

            if (noTracking == true)
                query = _dbSet.AsNoTracking();
            else
                query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        /// <summary>
        /// True if objects(s) exist in database that satisfy the specified filter.
        /// </summary>
        /// <param name="filter">Specified the filter expression</param>
        public bool Contains(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Count(filter) > 0;
        }

        /// <summary>
        /// Find object by keys.
        /// </summary>
        /// <param name="keys">The search keys.</param>
        public virtual T Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        /// <summary>
        /// Find the first object that satisfies the filter
        /// </summary>
        /// <param name="filter">The filter to use when searching for the object</param>
        public virtual T First(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public virtual void Add(T t)
        {
            _dbSet.Add(t);
        }

        public virtual void Remove(T t)
        {
            if (_context.Entry(t).State == EntityState.Detached)
            {
                _dbSet.Attach(t);
            }
            _dbSet.Remove(t);
        }

        public virtual int Remove(Expression<Func<T, bool>> filter)
        {
            var objects = GetWhere(filter, null);
            foreach (var obj in objects)
                _dbSet.Remove(obj);

            return objects.Count();
        }

        public virtual void Update(T t)
        {
            _dbSet.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
        }

    }
}
