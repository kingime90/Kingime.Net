﻿using Kingime.Net.Entity.General;
using System;

namespace Kingime.Net.DataAccess.General
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EFRepository<TEntity> : RepositoryBase<TEntity> where TEntity : class, IEntity
    {
        private IUnitOfWorkContext _workContext;

        /// <summary>
        /// 
        /// </summary>
        public override IUnitOfWorkContext WorkContext
        {
            get
            {
                return _workContext;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workContext"></param>
        public EFRepository(IUnitOfWorkContext workContext = null)
        {
            if (workContext == null)
            {
                workContext = UnitOfWorkContextManage.WorkContext();
            }
            //
            _workContext = workContext;
        }
    }
}
