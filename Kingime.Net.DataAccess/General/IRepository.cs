using Kingime.Net.Core.General;
using Kingime.Net.Entity.General;
using System.Collections.Generic;
using System.Linq;

namespace Kingime.Net.DataAccess.General
{
    /// <summary>
    /// 数据仓储接口
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型</typeparam>
    public interface IRepository<TEntity> : IDependency where TEntity : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        IUnitOfWorkContext WorkContext { get; }

        /// <summary>
        /// 当前查询数据实体集合
        /// </summary>
        IQueryable<TEntity> DbEntities { get; }

        /// <summary>
        /// 保存单个实体（新增）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="saveChange">是否执行保存</param>
        /// <returns></returns>
        int Save(TEntity entity, bool saveChange = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChange"></param>
        /// <returns></returns>
        int Save(IEnumerable<TEntity> entities, bool saveChange = true);

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="saveChange">是否执行删除</param>
        /// <returns></returns>
        int Delete(TEntity entity, bool saveChange = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChange"></param>
        /// <returns></returns>
        int Delete(IEnumerable<TEntity> entities, bool saveChange = true);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <param name="saveChange"></param>
        /// <returns></returns>
        int Delete<TKey>(TKey key, bool saveChange = true);

        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="saveChange">是否执行更新</param>
        /// <returns></returns>
        int Update(TEntity entity, bool saveChange = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChange"></param>
        /// <returns></returns>
        int Update(IEnumerable<TEntity> entities, bool saveChange = true);

        /// <summary>
        /// 根据主键获取单个实体
        /// </summary>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键数组</param>
        /// <returns></returns>
        TEntity GetById<TKey>(TKey key);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// 
        /// </summary>
        void Rollback();
    }
}
