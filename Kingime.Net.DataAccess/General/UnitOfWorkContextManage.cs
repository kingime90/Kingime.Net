﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingime.Net.DataAccess.General
{
    /// <summary>
    /// 工作单元上下文管理
    /// </summary>
    public class UnitOfWorkContextManage
    {

        private static Func<IUnitOfWorkContext> _workContext;

        /// <summary>
        /// 工作单元上下
        /// </summary>
        public static Func<IUnitOfWorkContext> WorkContext
        {
            get
            {
                return _workContext;
            }
        }

        /// <summary>
        /// 注册工作单元上下
        /// </summary>
        /// <param name="workContext"></param>
        public static void RegisterWorkContext(Func<IUnitOfWorkContext> workContext)
        {
            _workContext = workContext;
        }
    }
}
