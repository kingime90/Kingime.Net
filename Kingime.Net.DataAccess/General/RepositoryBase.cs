using Kingime.Net.Entity.General;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Kingime.Net.DataAccess.General
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract IUnitOfWorkContext WorkContext { get; }

        /// <summary>
        /// 
        /// </summary>
        public IQueryable<TEntity> DbEntities
        {
            get
            {
                return WorkContext.Set<TEntity>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChange"></param>
        /// <returns></returns>
        public int Delete(IEnumerable<TEntity> entities, bool saveChange = true)
        {
            WorkContext.RegisterDeleted(entities);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChange"></param>
        /// <returns></returns>
        public int Delete(TEntity entity, bool saveChange = true)
        {
            WorkContext.RegisterDeleted(entity);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="saveChange"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public int Delete<TKey>(TKey key, bool saveChange = true)
        {
            var entity = GetById(key);
            return Delete(entity, saveChange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity GetById<TKey>(TKey key)
        {
            return WorkContext.Set<TEntity>().Find(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChange"></param>
        /// <returns></returns>
        public int Save(IEnumerable<TEntity> entities, bool saveChange = true)
        {
            WorkContext.RegisterNew(entities);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChange"></param>
        /// <returns></returns>
        public int Save(TEntity entity, bool saveChange = true)
        {
            WorkContext.RegisterNew(entity);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChange"></param>
        /// <returns></returns>
        public int Update(IEnumerable<TEntity> entities, bool saveChange = true)
        {
            WorkContext.RegisterModified(entities);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChange"></param>
        /// <returns></returns>
        public int Update(TEntity entity, bool saveChange = true)
        {
            WorkContext.RegisterModified(entity);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            return WorkContext.Commit();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Rollback()
        {
            WorkContext.Rollback();
        }
    }
}
