using Microsoft.EntityFrameworkCore;
using WpfBase.Models.DBEntity;
using System.Configuration;

namespace WpfBase.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<M_AccountEntity> M_AccountEntitys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M_AccountEntity>().ToTable("M_Account");
        }
    }
}
