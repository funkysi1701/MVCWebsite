using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Funkysi1701.Website.Models
{
    public class stuff
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class stuffDBContext : DbContext
    {
        public DbSet<stuff> stuff { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}