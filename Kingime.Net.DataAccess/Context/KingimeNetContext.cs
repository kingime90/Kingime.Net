using Kingime.Net.Entity;
using System.Data.Entity;

namespace Kingime.Net.DataAccess.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class KingimeNetContext: DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public KingimeNetContext()
            : base("name=KingimeNet")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public KingimeNetContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasKey(m => m.Id);
        }
    }
}
