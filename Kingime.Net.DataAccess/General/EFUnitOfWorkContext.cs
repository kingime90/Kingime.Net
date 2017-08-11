using Kingime.Net.DataAccess.Context;
using System.Data.Entity;

namespace Kingime.Net.DataAccess.General
{
    /// <summary>
    /// 
    /// </summary>
    public class EFUnitOfWorkContext : UnitOfWorkContextBase
    {
        private DbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        public override DbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public EFUnitOfWorkContext(DbContext dbContext = null)
        {
            if (dbContext == null)
            {
                dbContext = DbContextManage.DbContext();
            }
            _dbContext = dbContext;
        }
    }
}
