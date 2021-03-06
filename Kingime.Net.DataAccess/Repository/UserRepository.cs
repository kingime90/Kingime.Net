﻿using System;
using System.Linq;
using Kingime.Net.DataAccess.General;
using Kingime.Net.DataAccess.IRepository;
using Kingime.Net.Entity;

namespace Kingime.Net.DataAccess.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workContext"></param>
        public UserRepository(IUnitOfWorkContext workContext = null) : base(workContext)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetByUsername(string username)
        {
            return DbEntities.FirstOrDefault(x => x.Username == username);
        }
    }
}
