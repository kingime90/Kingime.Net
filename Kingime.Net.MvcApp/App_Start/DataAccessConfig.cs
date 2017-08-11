using Kingime.Net.DataAccess.Context;
using Kingime.Net.DataAccess.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kingime.Net.MvcApp
{
    /// <summary>
    /// 数据访问配置
    /// </summary>
    public class DataAccessConfig
    {
        /// <summary>
        /// 注册数据访问配置
        /// </summary>
        public static void Register()
        {
            UnitOfWorkContextManage.RegisterWorkContext(RegisterWorkContext);
            DbContextManage.RegisterDbContext(RegisterDbContext);
        }

        /// <summary>
        /// 注册工作单元上下
        /// </summary>
        /// <returns></returns>
        public static EFUnitOfWorkContext RegisterWorkContext()
        {
            return new EFUnitOfWorkContext();
        }

        /// <summary>
        /// 注册数据库上下文
        /// </summary>
        /// <returns></returns>
        public static KingimeNetContext RegisterDbContext()
        {
            return new KingimeNetContext();
        }
    }
}