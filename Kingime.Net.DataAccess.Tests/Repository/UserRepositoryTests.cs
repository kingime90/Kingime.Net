﻿using Kingime.Net.DataAccess.Context;
using Kingime.Net.DataAccess.General;
using Kingime.Net.DataAccess.Repository;
using Kingime.Net.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingime.Net.DataAccess.Tests.Repository
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class UserRepositoryTests
    {
        /// <summary>
        /// 初始化
        /// </summary>
        [SetUp]
        public static void Initialize()
        {
            UnitOfWorkContextManage.RegisterWorkContext(GetEFUnitOfWorkContext);
            DbContextManage.RegisterDbContext(GetKingimeNetContext);
        }

        public static EFUnitOfWorkContext GetEFUnitOfWorkContext()
        {
            return new EFUnitOfWorkContext();
        }

        public static KingimeNetContext GetKingimeNetContext()
        {
            return new KingimeNetContext();
        }

        /// <summary>
        /// 测试保存
        /// </summary>
        [Test]
        public void SaveTest()
        {
            var workContext = UnitOfWorkContextManage.WorkContext();
            var repository = new UserRepository(workContext);
            var user = new User
            {
                Username = "dev011",
                Password = "123456",
                Nickname = "dev011",
                Gender = 1,
                Mobile = "13535555555",
                RegisterDate = DateTime.Now
            };
            repository.Save(user, false);
            //repository.Commit();
            var result = workContext.Commit();
            Assert.IsTrue(result > 0);
        }
    }
}
