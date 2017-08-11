using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingime.Net.Entity.General
{
    /// <summary>
    /// 数据实体基类
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class Entity<TKey> : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public TKey Id { get; set; }
    }
}
