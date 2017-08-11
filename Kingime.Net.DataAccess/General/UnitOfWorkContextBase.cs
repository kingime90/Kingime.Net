using Kingime.Net.Entity.General;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Kingime.Net.DataAccess.General
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class UnitOfWorkContextBase : IUnitOfWorkContext
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract DbContext DbContext { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCommitted
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            if (IsCommitted)
            {
                return 0;
            }
            //
            int result = DbContext.SaveChanges();
            IsCommitted = true;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }
            //
            DbContext.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Rollback()
        {
            IsCommitted = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        public void RegisterDeleted<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            try
            {
                SetAutoDetectChangesEnabled(false);
                foreach (TEntity entity in entities)
                {
                    RegisterDeleted(entity);
                }
            }
            finally
            {
                SetAutoDetectChangesEnabled(true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            Entry(entity).State = EntityState.Deleted;
            IsCommitted = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        public void RegisterModified<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            try
            {
                SetAutoDetectChangesEnabled(false);
                foreach (TEntity entity in entities)
                {
                    RegisterModified(entity);
                }
            }
            finally
            {
                SetAutoDetectChangesEnabled(true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void RegisterModified<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var entityEntry = Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                DbContext.Set<TEntity>().Attach(entity);
            }
            entityEntry.State = EntityState.Modified;
            IsCommitted = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        public void RegisterNew<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            try
            {
                SetAutoDetectChangesEnabled(false);
                foreach (TEntity entity in entities)
                {
                    RegisterNew(entity);
                }
            }
            finally
            {
                SetAutoDetectChangesEnabled(true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void RegisterNew<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var entityEntry = Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                entityEntry.State = EntityState.Added;
            }
            IsCommitted = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity
        {
            return DbContext.Set<TEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return DbContext.Entry(entity);
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否通过 System.Data.Entity.DbContext 和相关类的方法自动调用 System.Data.Entity.Infrastructure.DbChangeTracker.DetectChanges 方法。默认值为 true。
        /// </summary>
        /// <param name="autoDetectChangesEnabled"></param>
        protected virtual void SetAutoDetectChangesEnabled(bool autoDetectChangesEnabled = true)
        {
            DbContext.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
        }
    }
}
