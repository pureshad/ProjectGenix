using Genix.Core;
using Genix.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Genix.Data.Repository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext _context;
        private DbSet<TEntity> _entities;

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();
                return _entities;
            }
        }

        public IQueryable<TEntity> Table => Entities;

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(e), e);
            }
        }

        private string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException e)
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException e)
                    {
                        //IGNORE
                    }
                });
            }

            try
            {
                _context.SaveChanges();
                return e.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.RemoveRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbUE)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbUE), dbUE);
            }
        }

        public TEntity GetById(object id) => Entities.Find(id);

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbUE)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbUE), dbUE);
            }
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.AddRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbUE)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbUE), dbUE);
            }
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Update(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbUE)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbUE), dbUE);
            }
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.UpdateRange(entities: entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbUE)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbUE), dbUE);
            }
        }
    }
}
