using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoltsAndPrices.Data.Domain;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;

using System.Reflection;

namespace BoltsAndPrices.Data.Repositories
{
    public partial class UnitOfWork : IUnitOfWork, IDisposable
    {
        private BoltsAndPricesContext _context;

        public UnitOfWork(BoltsAndPricesContext context)
        {
            _context = context;
            _context.Configuration.UseDatabaseNullSemantics = true;
        }

        public void Copy(object entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Added;
        }

        public void Detach(object entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Detached;
        }

        public void Delete(object entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        private IEnumerable<object> GetPersistingEntities()
        {
            return _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                                            e.State == EntityState.Modified)
                                .Select(e => e.Entity);
        }

        private IEnumerable<PropertyInfo> GetStringProperties(object entity)
        {
            if (entity == null)
            {
                return new List<PropertyInfo>();
            }

            return entity.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string));
        }

        public void Save()
        {
            // Perform validation (or let Model handle validation in partial classes etc)
            // Check changed values, apply same changes to product etc

            // Trim spaces from all string properties
            foreach (var entity in GetPersistingEntities())
            {
                foreach (var propertyInfo in GetStringProperties(entity))
                {
                    if (propertyInfo.CanWrite)
                    {
                        var value = (string)propertyInfo.GetValue(entity, null);

                        if (value == null || value.Length == 0)
                        {
                            continue;
                        }

                        var trimmedValue = value.Trim();

                        if (trimmedValue.Length == 0)
                        {
                            propertyInfo.SetValue(entity, String.Empty, null);
                        }
                        else if (value.Length != trimmedValue.Length)
                        {
                            propertyInfo.SetValue(entity, trimmedValue, null);
                        }
                    }
                }
            }

            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
